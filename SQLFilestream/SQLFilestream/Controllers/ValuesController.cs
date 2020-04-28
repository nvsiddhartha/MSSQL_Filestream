using System.IO;
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
            var files = await context.MyFileStreamTable.ToListAsync();
            return await Task.FromResult(Ok(files.Count()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var file = context.MyFileStreamTable.Where(i => i.Fsdescription == "capture").FirstOrDefault();

            return File(file.Fsblob, "image/png");
        }

        //[HttpGet("{id}")]
        //public async Task<FileContentResult> DownloadAsync(string id)
        //{
        //    var file = await context.MyFileStreamTable.Where(i => i.Fsdescription == "capture").FirstOrDefaultAsync();

        //    return new FileContentResult(file.Fsblob, "image/png")
        //    {
        //        FileDownloadName = file.Fsdescription
        //    };
        //}

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var guid = System.Guid.NewGuid();
            var file = new MyFileStreamTable
            {
                Fsid = guid,
                Fsdescription = "A File " + guid.ToString(),
                Fsblob = System.IO.File.ReadAllBytes(".//Resources//textfile.txt")
            };

            context.MyFileStreamTable.Add(file);
            context.SaveChanges();

            return await Task.FromResult(Ok());
        }
    }
}
