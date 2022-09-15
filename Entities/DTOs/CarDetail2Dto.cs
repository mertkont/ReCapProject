using System.Reflection.Metadata;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetail2Dto : IDto
    {
        public string ColorName { get; set; }
        public string Description { get; set; }
    }
}