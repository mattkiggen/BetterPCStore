using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterPCStore.Api.DTOs;
using BetterPCStore.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterPCStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Brand
        [HttpGet]
        public ActionResult<ICollection<Brand>> Get()
        {
            var brands = _context.Brands.ToList();
            return brands;
        }

        // GET: api/Brand/id
        [HttpGet("{id}")]
        public ActionResult<Brand> Get(Guid id)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null) return NotFound();
            return brand;
        }

        // POST: api/Brand
        [HttpPost]
        public ActionResult<Brand> Post([FromBody] CreateBrandDto dto)
        {
            var brand = new Brand {Name = dto.Name, Slug = dto.Slug};
            var result = _context.Brands.Add(brand);
            _context.SaveChanges();
            return result.Entity;
        }
        
        // PUT: api/Brand/id
        [HttpPut("{id}")]
        public ActionResult<Brand> Put(Guid id, [FromBody] CreateBrandDto dto)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null) return NotFound();
            
            brand = new Brand
            {
                Id = id,
                Name = dto.Name,
                Slug = dto.Slug
            };

            _context.Brands.Update(brand);
            return brand;
        }

        // DELETE: api/Brand/id
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(Guid id)
        {
            var brand = _context.Brands.Find(id);
            if (brand == null) return NotFound();

            _context.Brands.Remove(brand);
            _context.SaveChanges();
            
            return "Brand deleted successfully";
        }
    }
}
