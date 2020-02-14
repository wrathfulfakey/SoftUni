namespace Andreys.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Andreys.Models.Enum;

    public class Product
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }

        public ProductGender Gender { get; set; }
    }
}
