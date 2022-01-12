using System.ComponentModel.DataAnnotations.Schema;

namespace BetterPCStore.Data.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    
    public decimal Price { get; set; }

    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    [ForeignKey("Brand")]
    public Guid BrandId { get; set; }
    public Brand Brand { get; set; }
}