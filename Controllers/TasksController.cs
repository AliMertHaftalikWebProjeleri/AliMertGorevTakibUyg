using AliMertGorevTakip.Data;
using AliMertGorevTakip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStatus = AliMertGorevTakip.Models.TaskStatus;

namespace AliMertGorevTakip.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TasksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _context.Tasks
                .Where(t => t.AssignedUserId == userId)
                .ToListAsync();
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title)) return BadRequest();

            var userId = _userManager.GetUserId(User);
            var task = new TaskItem
            {
                Title = title,
                Description = description,
                Status = TaskStatus.ToDo,
                AssignedUserId = userId,
                CreatedAt = DateTime.Now
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return Json(new { success = true, taskId = task.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int taskId, string status)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null) return NotFound();

            // Verify ownership or Admin role
            var userId = _userManager.GetUserId(User);
            if (task.AssignedUserId != userId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            if (Enum.TryParse<TaskStatus>(status, true, out var newStatus))
            {
                task.Status = newStatus;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            var userId = _userManager.GetUserId(User);
            if (task.AssignedUserId != userId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}
