using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetterPCStore.Api.DTOs;
using BetterPCStore.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetterPCStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Category
        [HttpGet]
        public ICollection<CategoryDto> Get()
        {
            var categories = _context.Categories.ToList();
            return categories.Select(c => new CategoryDto {Id = c.Id, Name = c.Name, Slug = c.Slug}).ToList();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(Guid id)
        {
            var result = _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == id);
            
            if (result == null) return NotFound();

            return result;
        }

        // POST: api/Category
        [HttpPost]
        public Category Post([FromBody] CreateCategoryDto dto)
        {
            var category = new Category {Name = dto.Name, Slug = dto.Slug};
            var result = _context.Categories.Add(category);
            _context.SaveChanges();
            
            return result.Entity;
        }
    }
}
