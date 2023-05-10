using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Db.Entities
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
