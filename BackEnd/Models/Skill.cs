using System.ComponentModel.DataAnnotations;
namespace SKillsSet.Models
{
    public class Skill{
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; } 

    }
}