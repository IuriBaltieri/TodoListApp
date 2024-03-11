using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class Todo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        public bool Completed { get; set; }
    };
}
