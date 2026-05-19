using AliMertGorevTakip.Data;
using AliMertGorevTakip.Models;
using AliMertGorevTakip.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStatus = AliMertGorevTakip.Models.TaskStatus;

namespace AliMertGorevTakip.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var totalTasks = await _context.Tasks.CountAsync();
            var completedTasks = await _context.Tasks.CountAsync(t => t.Status == TaskStatus.Done);
            var totalUsers = await _userManager.Users.CountAsync();

            ViewBag.TotalTasks = totalTasks;
            ViewBag.CompletedTasks = completedTasks;
            ViewBag.TotalUsers = totalUsers;
            ViewBag.CompletionRate = totalTasks == 0 ? 0 : Math.Round((double)completedTasks / totalTasks * 100, 1);

            return View();
        }

        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users
                .Include(u => u.Tasks)
                .Select(u => new AdminUserViewModel
                {
                    UserId = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    TotalTasks = u.Tasks.Count,
                    CompletedTasks = u.Tasks.Count(t => t.Status == TaskStatus.Done)
                })
                .ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users
                .Select(u => new { u.Id, u.FullName, u.Email })
                .ToListAsync();
            return Json(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetChartData()
        {
            var todo = await _context.Tasks.CountAsync(t => t.Status == TaskStatus.ToDo);
            var inProgress = await _context.Tasks.CountAsync(t => t.Status == TaskStatus.InProgress);
            var done = await _context.Tasks.CountAsync(t => t.Status == TaskStatus.Done);

            return Json(new { todo, inProgress, done });
        }

        [HttpPost]
        public async Task<IActionResult> AssignTask(string userId, string title, string description)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(title)) return BadRequest();

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

            return Json(new { success = true });
        }
    }
}
