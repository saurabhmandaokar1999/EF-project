using EF_project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EF_project.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet("/getAllCurrencies")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await _appDbContext.Currency.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyAsync([FromRoute] int id)
        {
            var result = await _appDbContext.Currency.FindAsync(id);
            return Ok(result);
        }

        [HttpGet("byTitle/{title}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string title)
        {
            var result = await _appDbContext.Currency.FirstOrDefaultAsync(n => n.Title == title);
            return Ok(result);
        }
        [HttpGet("{title}")]
        public async Task<IActionResult> GetCurrencyByNameAsync([FromRoute] string title, [FromQuery] string? description)
        {
            var result = await _appDbContext.Currency.FirstOrDefaultAsync(n => n.Title == title
            && ((description.IsNullOrEmpty())|| n.Description==description));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllCurrencyAsync([FromBody] List<int> ids)
        {
            var result = await _appDbContext.Currency.Where(x=>ids.Contains(x.Id)).ToListAsync();
            return Ok(result);
        }
    }
}
