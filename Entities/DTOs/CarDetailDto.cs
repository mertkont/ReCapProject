namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
    }
}