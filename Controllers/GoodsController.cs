using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iCartApi.Models;
using ServiceBase;

namespace iCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly myDBContainer db;

        public GoodsController(myDBContainer context)
        {
            db = context;
        }

        #region PrepareData

        #region GetRunningNumber
        [HttpGet("GetRunningNumber")]
        public async Task<ActionResult<string>>  GetRunningNumber()
        {
            var defaultNumber  = 1;
            var runningNumber = "";
            var runningStart = "";
            var dateNow = Convert.ToDateTime(SystemDateTime.Now).ToString("yyyy/MM/dd");
            if (dateNow != null)
            {
                if (defaultNumber <= 9)
                {
                    runningStart = "0" + ConvertHelper.ToString(defaultNumber);
                }

                dateNow = dateNow.Replace("/", "");
                var format = "GN" + dateNow + "-";
                runningNumber = format + runningStart;
            }

            return runningNumber;
        }
        #endregion
        
        #region GetListUnit
        [HttpGet("GetListUnit")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetListUnit()
        {
            return await db.Unit
            .Where(x => x.IsDelete == false && x.IsInactive == false)
            .OrderBy(x => x.CreatedDate)
            .ToListAsync();
        }
        #endregion

        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<view_GoodsUnit>>> GetGoods()
        {
            return await db.view_GoodsUnit
            .Where(x => x.IsBaseUnit == true && x.IsDelete == false && x.IsInactive == false)
            .OrderBy(x => x.CreatedDate)
            .ToListAsync();
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoodsModel>> GetGoods(string id)
        {
            var objGoods = new GoodsModel();
            if (!string.IsNullOrEmpty(id))
            {
                var goods = await db.Goods.FirstOrDefaultAsync(x => x.IsDelete == false && x.GoodsID == id);
                if (goods != null)
                {
                    objGoods.goodsID = goods.GoodsID;
                    objGoods.goodsNo = goods.GoodsNo;
                    objGoods.goodsCode = goods.GoodsCode;
                    objGoods.goodsName = goods.GoodsName;
                    objGoods.goodsNameEng = goods.GoodsNameEng;

                    #region Set LisUnit
                    var unit = db.view_GoodsUnit.Where(x => x.GoodsID == id).OrderBy(x => x.CreatedDate).ToList();
                    if (unit != null && unit.Count > 0)
                    {   var ListUnit = new List<UnitModel>();
                        foreach (var un in unit)
                        {
                            ListUnit.Add(new UnitModel(){
                                uid = Guid.NewGuid().ToString(),
                                barcode = un.Barcode,
                                unitNo = un.UnitNo,
                                unitName = un.UnitName,
                                isBaseUnit = un.IsBaseUnit
                            });
                        }

                        objGoods.listUnit = ListUnit;
                    }
                    #endregion
                }
                else 
                {
                    return NotFound();
                }
            }

            return objGoods;
        }

        // PUT: api/Goods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoods(string id, Goods goods)
        {
            if (id != goods.GoodsID)
            {
                return BadRequest();
            }

            db.Entry(goods).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Goods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Goods>> PostGoods(Goods goods)
        {
            //db.Goods.Add(goods);
            //await db.SaveChangesAsync();
            return goods;
            // return CreatedAtAction("GetGoods", new { id = goods.GoodsID }, goods);
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Goods>> DeleteGoods(long id)
        {
            var goods = await db.Goods.FindAsync(id);
            if (goods == null)
            {
                return NotFound();
            }

            db.Goods.Remove(goods);
            await db.SaveChangesAsync();

            return goods;
        }

        private bool GoodsExists(string id)
        {
            return db.Goods.Any(e => e.GoodsID == id);
        }

        // GET: api/Goods/5
        [HttpGet("GetGoodsByBarcode/{Barcode}")]
        public async Task<ActionResult<view_GoodsUnit>> GetGoodsByBarcode(string Barcode)
        {
            var objGoods = new view_GoodsUnit();
            if (!string.IsNullOrEmpty(Barcode))
            {
                objGoods = await db.view_GoodsUnit.FirstOrDefaultAsync(x => x.IsDelete == false && x.Barcode == Barcode);
            }

            return objGoods;
        }
    }
}
