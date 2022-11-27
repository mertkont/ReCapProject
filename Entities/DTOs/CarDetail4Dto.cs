using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetail4Dto : IDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string? ColorName { get; set; }
        public string? BrandName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}