using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Date { get; set; }
        public int Kilojoules { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }

    }
}
