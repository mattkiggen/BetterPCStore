using System.ComponentModel.DataAnnotations;

namespace BetterPCStore.Data.DTOs;

public class CreateCategoryDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Slug { get; set; }
}