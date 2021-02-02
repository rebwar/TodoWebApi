using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class ItemData
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Done { get; set; } = false;
    }
}