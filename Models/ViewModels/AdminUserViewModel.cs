namespace AliMertGorevTakip.Models.ViewModels
{
    public class AdminUserViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public double CompletionPercentage => TotalTasks == 0 ? 0 : Math.Round((double)CompletedTasks / TotalTasks * 100, 1);
    }
}
