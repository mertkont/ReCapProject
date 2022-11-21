#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Core.Entities;

namespace Entities.Concrete
{
    public partial class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}