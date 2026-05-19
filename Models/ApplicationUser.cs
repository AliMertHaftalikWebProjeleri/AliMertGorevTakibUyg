using Microsoft.AspNetCore.Identity;

namespace AliMertGorevTakip.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
