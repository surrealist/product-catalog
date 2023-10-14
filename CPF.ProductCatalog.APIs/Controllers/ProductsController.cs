using CPF.ProductCatalog.APIs.Models;
using CPF.ProductCatalog.APIs.Services;
using CPF.ProductCatalog.Models;
using CPF.ProductCatalog.Services.Data; 
using Microsoft.AspNetCore.Mvc;

namespace CPF.ProductCatalog.APIs.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDb db;
        private readonly ILoggingService log;
        private readonly IWebHostEnvironment env;

        public ProductsController(AppDb db, ILoggingService log, IWebHostEnvironment env)
        {
            this.db = db;
            this.log = log;
            this.env = env;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var items = db.Products.ToList();
             
            log.Info("GET /api/v1/products");

            return Ok(items);
        }

        [HttpGet("{code}")]
        public ActionResult GetById(string code)
        {
            var item = db.Products.Find(code); // .SingleOrDefault(x => x.Code == code);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        [HttpGet("{code}/picture")]
        public ActionResult GetPictureById(string code)
        {
            var item = db.Products.Find(code); // .SingleOrDefault(x => x.Code == code);
            if (item == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(env.ContentRootPath, item.PictureFileName);
            return PhysicalFile(filePath, "image/png", $"{item.Code}.png");
        }

        [HttpPost]
        public ActionResult CreateNew([FromForm] ProductRequest item)
        {
            if (item.File == null || item.File.Length == 0)
            {
                return BadRequest();
            }

            var now = DateTimeOffset.Now;
            var fileName = $"{item.Code}_{now:yyyyMMdd_HHmmss}.png";
            using (var s = new FileStream(fileName, FileMode.Create))
            {
                item.File.CopyTo(s);
            }

            var p = new Product();
            p.Code = item.Code;
            p.Name = item.Name;
            p.PictureFileName = fileName;
            p.CreatedBy = "Unknown";
            p.CreatedOn = now;


            db.Products.Add(p);
            db.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { code = item.Code }, p);
        }

        [HttpPut("{code}")]
        public ActionResult Update(string code, [FromForm] ProductRequest item)
        {
            if (code != item.Code)
            {
                return BadRequest("Product code is invalid.");
            }

            string? fileName = null;
            if (item.File is not null && item.File.Length > 0)
            { 
                var now = DateTimeOffset.Now;
                fileName = $"{item.Code}_{now:yyyyMMdd_HHmmss}.png";
                using (var s = new FileStream(fileName, FileMode.Create))
                {
                    item.File.CopyTo(s);
                }
            }

            var p = db.Products.Find(code);
            if (p is not null)
            {
                p.Name = item.Name;
                if (fileName is not null)
                    p.PictureFileName = fileName;
            }             
            db.SaveChanges();
            return NoContent();
        }
    }
}
