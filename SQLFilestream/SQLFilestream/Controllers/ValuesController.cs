using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLFilestream.Models;

namespace SQLFilestream.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MyFileStreamDBContext context;

        public ValuesController(
            MyFileStreamDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var files = await context.MyFileStreamTable.Where(i => i.Fsdescription == "capture").ToListAsync();
            return await Task.FromResult(Ok());
        }
    }
}
