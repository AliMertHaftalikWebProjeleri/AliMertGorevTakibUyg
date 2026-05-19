using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AliMertGorevTakip.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.ToDo;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? AssignedUserId { get; set; }

        [ForeignKey("AssignedUserId")]
        public virtual ApplicationUser? AssignedUser { get; set; }
    }
}
