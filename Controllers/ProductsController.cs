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
    public class ProductsController : ControllerBase
    {
        private readonly myDBContainer db;

        public ProductsController(myDBContainer context)
        {
            db = context;
        }

        #region prepareData

        #region getRunningNumber
        [HttpGet("getRunningNumber")]
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
        
        #region getListUnit
        [HttpGet("getListUnit")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetListUnit()
        {
            return await db.Unit
            .Where(x => x.isDelete == false && x.isInactive == false)
            .OrderBy(x => x.createdDate)
            .ToListAsync();
        }
        #endregion

        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<view_ProductsUnit>>> GetProducts()
        {
            return await db.view_ProductsUnit
            .Where(x => x.isBaseUnit == true && x.isDelete == false && x.isInactive == false)
            .OrderBy(x => x.createdDate)
            .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsModel>> GetProducts(string id)
        {
            try
            {
                var objProducts = new ProductsModel();
                if (!string.IsNullOrEmpty(id))
                {
                    var product = await db.Products.FirstOrDefaultAsync(x => x.isDelete == false && x.productID == id);
                    if (product != null)
                    {
                        objProducts.productID = product.productID;
                        objProducts.productNo = product.productNo;
                        objProducts.productCode = product.productCode;
                        objProducts.productName = product.productName;
                        objProducts.productNameEng = product.productNameEng;

                        #region Set LisUnit
                        var unit = db.view_ProductsUnit.Where(x => x.productID == id).OrderBy(x => x.createdDate).ToList();
                        if (unit != null && unit.Count > 0)
                        {   var ListUnit = new List<UnitModel>();
                            foreach (var un in unit)
                            {
                                ListUnit.Add(new UnitModel(){
                                    uid = Guid.NewGuid().ToString(),
                                    barcode = un.barcode,
                                    unitNo = un.unitNo,
                                    unitName = un.unitName,
                                    isBaseUnit = un.isBaseUnit
                                });
                            }

                            objProducts.listUnit = ListUnit;
                        }
                        #endregion
                    }
                }

                return objProducts;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(string id, Products product)
        {
            if (id != product.productID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products product)
        {
            //db.Products.Add(product);
            //await db.SaveChangesAsync();
            return product;
            // return CreatedAtAction("GetProducts", new { id = product.ProductsID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(long id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return product;
        }

        private bool ProductsExists(string id)
        {
            return db.Products.Any(e => e.productID == id);
        }

        // GET: api/Products/5
        [HttpGet("GetProductsByBarcode/{barcode}")]
        public async Task<ActionResult<view_ProductsUnit>> GetProductsByBarcode(string barcode)
        {
            var objProducts = new view_ProductsUnit();
            if (!string.IsNullOrEmpty(barcode))
            {
                objProducts = await db.view_ProductsUnit.FirstOrDefaultAsync(x => x.isDelete == false && x.barcode == barcode);
            }

            return objProducts;
        }
    }
}
