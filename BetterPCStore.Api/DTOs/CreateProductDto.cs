using System.ComponentModel.DataAnnotations;

namespace BetterPCStore.Api.DTOs;

public class CreateProductDto
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Slug { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public Guid CategoryId { get; set; }
    
    [Required]
    public Guid BrandId { get; set; }
}