using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iCartApi.Models;

namespace iCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly GoodsContext db;

        public GoodsController(GoodsContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<view_GoodsUnit>>> GetGoods()
        {
            return await db.view_GoodsUnit.ToListAsync();
            //.Where(x => x.IsDelete == false).OrderBy(x => x.CreatedDate)
            //return CreatedAtAction("GetGoods", new { id = '1' }, ListData);
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Goods>> GetGoods(string id)
        {
            var goods = await db.Goods.FirstOrDefaultAsync(x => x.IsDelete == false && x.GoodsID == id);

            if (goods == null)
            {
                return NotFound();
            }

            return goods;
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
            db.Goods.Add(goods);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetGoods", new { id = goods.GoodsID }, goods);
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
    }
}
