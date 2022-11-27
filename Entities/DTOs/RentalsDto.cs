using System;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalsDto : IDto
    {
        public int RentalId { get; set; }
        public string BrandName { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}