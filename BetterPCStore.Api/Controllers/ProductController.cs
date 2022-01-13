using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterPCStore.Data.DTOs;
using BetterPCStore.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetterPCStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Product
        [HttpGet]
        public ActionResult<ICollection<ProductDto>> Get()
        {
            var query = from p in _context.Set<Product>()
                join b in _context.Set<Brand>()
                    on p.BrandId equals b.Id
                join c in _context.Set<Category>()
                    on p.CategoryId equals c.Id
                select new ProductDto
                {
                    Title = p.Title,
                    Slug = p.Slug,
                    Description = p.Description,
                    Price = p.Price,
                    NumInStock = p.NumInStock,
                    Meta = new ProductMetaDto
                    {
                        Category = new CategoryDto
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Slug = c.Slug,    
                        },
                        Brand = new BrandDto
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Slug = b.Slug
                        }
                    }
                };
            
            return query.ToList();
        }

        // GET: api/Product/id
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(Guid id)
        {
            var query = from p in _context.Set<Product>()
                join c in _context.Set<Category>()
                    on p.CategoryId equals c.Id
                join b in _context.Set<Brand>()
                    on p.BrandId equals b.Id
                where p.Id == id
                select new ProductDto
                {
                    Title = p.Title,
                    Slug = p.Slug,
                    Description = p.Description,
                    Price = p.Price,
                    NumInStock = p.NumInStock,
                    Meta = new ProductMetaDto
                    {
                        Category = new CategoryDto
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Slug = c.Slug
                        },
                        Brand = new BrandDto
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Slug = b.Slug
                        }
                    }
                };
                
            
            var product = query.FirstOrDefault();
            if (product == null) return NotFound();

            return product;
        }

        // POST: api/Product
        [HttpPost]
        [Authorize("AdminAccess")]
        public ActionResult<Product> Post([FromBody] CreateProductDto dto)
        {
            var product = new Product
            {
                Title = dto.Title,
                Slug = dto.Slug,
                Description = dto.Description,
                Price = dto.Price,
                NumInStock = dto.NumInStock,
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId
            };

            var result = _context.Products.Add(product);
            _context.SaveChanges();
            return result.Entity;
        }

        // PUT: api/Product/id
        [HttpPut("{id}")]
        [Authorize("AdminAccess")]
        public ActionResult<Product> Put(Guid id, [FromBody] CreateProductDto dto)
        {
            var product = new Product
            {
                Id = id,
                Title = dto.Title,
                Slug = dto.Slug,
                Description = dto.Description,
                Price = dto.Price,
                NumInStock = dto.NumInStock,
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId
            };
            
            var result = _context.Products.Update(product);
            _context.SaveChanges();
            return result.Entity;
        }

        // DELETE: api/Product/id
        [HttpDelete("{id}")]
        [Authorize("AdminAccess")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _context.Products.Find(id);
            if (result == null) return NotFound();

            _context.Remove(result);
            _context.SaveChanges();
            return "Product successfully deleted.";
        }
    }
}
