using EF_project.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_project.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet("/getAllLanguage")]
        public async Task<IActionResult> GetAllLaguages() {
            var result =await _appDbContext.Language.ToListAsync();
            return Ok(result);
        }
    }
}
