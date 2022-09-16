namespace Application.Features.Models.Dtos;

public class ModelGetbyIdDto
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String BrandName { get; set; }
    public decimal DailyPrice { get; set; }
    public String ImageUrl { get; set; }
}