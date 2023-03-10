using BardeMoeBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BardeMoeBack.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly AplicationDBContext _context;
        

        public BeersController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> get() {
            try
            {
                var listBeers = await _context.Beers.ToListAsync();
                return Ok(listBeers);   
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{BeerCode}")]
        public async Task<IActionResult> get(int BeerCode)
        {

            try
            {
                var Beer = await _context.Beers.FindAsync(BeerCode);

                if (Beer == null)
                {
                    return NotFound();
                }

                return Ok(Beer);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }



         [HttpDelete("{BeerCode}")]
         public async Task<IActionResult> DeleteBeer(int BeerCode) {
             try {
                 var Beer= await  _context.Beers.FindAsync(BeerCode);

                 if (Beer == null) {
                     return NotFound();
                 }

                     _context.Beers.Remove(Beer); 

                     await _context.SaveChangesAsync();

                  return NoContent();                    
                 }

             catch(Exception ex) { 
                 return BadRequest(ex.Message);
             }
         }

        [HttpPost]
         public async Task<IActionResult> BuyBeer(BuyBeers buyBeer) {
            try
            {
                var @Cuantity = buyBeer.Cuantity;
                var @BeerCode = buyBeer.BeerCode;
                _ = await _context.Database.ExecuteSqlRawAsync($@" EXEC BuyBeer
                                           {@BeerCode},{@Cuantity}");
                return Ok(buyBeer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

       




    }
}
