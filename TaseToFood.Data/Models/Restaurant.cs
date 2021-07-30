using System.ComponentModel.DataAnnotations;

namespace TaseToFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name ="Food Served")]
        public CuisineType Cuisine { get; set; }

    }
}
