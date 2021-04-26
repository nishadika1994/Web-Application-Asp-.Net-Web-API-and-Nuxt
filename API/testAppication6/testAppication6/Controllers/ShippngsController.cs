using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAppication6.Models;

namespace testAppication6.Controllers
{
    //API controller for shipping table

    [Route("api/[controller]")]
    [ApiController]
    public class ShippngsController : ControllerBase
    {
        private readonly TestDB1Context dbObj;

        public ShippngsController(TestDB1Context context)
        {
            dbObj = context;
        }

        // GET: api/Shippngs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shippng>>> GetShippngs()
        {
            return await dbObj.Shippngs.ToListAsync();
        }

        // GET: api/Shippngs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shippng>> GetShippng(int id)
        {
            var shippng = await dbObj.Shippngs.FindAsync(id);

            if (shippng == null)
            {
                return NotFound();
            }

            return shippng;
        }

        // POST: api/Shippngs
        [HttpPost]
        public async Task<ActionResult<Shippng>> PostShippng(Shippng shippng)
        {
            AccountsController accres = new AccountsController(dbObj);
            shippng.AccId = accres.getAccountResponseID();

            dbObj.Shippngs.Add(shippng);
            try
            {
                await dbObj.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShippngExists(shippng.ShipId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShippng", new { id = shippng.ShipId }, shippng);
        }

        private bool ShippngExists(int id)               //Getting forien key
        {
            return dbObj.Shippngs.Any(e => e.ShipId == id);
        }
    }
}
