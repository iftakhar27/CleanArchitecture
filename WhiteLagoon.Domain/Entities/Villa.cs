using System.ComponentModel.DataAnnotations;
using WhiteLagoon.Domain.Common;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa : AuditableEntity
	{
        public int Id { get; set; }
		public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price per night")]
        public double Price { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }        
    }
}
