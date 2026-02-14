using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace CalorieTrackerApp.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // this is a dummy implementation
            return Task.CompletedTask;
        }
    }
}
