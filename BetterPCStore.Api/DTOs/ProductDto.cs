namespace BetterPCStore.Api.DTOs;

public class ProductDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int NumInStock { get; set; }
    public ProductMetaDto Meta { get; set; }
}