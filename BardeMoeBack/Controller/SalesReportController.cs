using BardeMoeBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BardeMoeBack.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalesReportController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public SalesReportController(AplicationDBContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ReportBuy>> SalesReport()
        {
            try
            {
                var salesreport =  _context.ReportBuy.FromSqlInterpolated($"EXEC SalesReport ")
                    .AsAsyncEnumerable();

     
                return Ok(salesreport);
            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
