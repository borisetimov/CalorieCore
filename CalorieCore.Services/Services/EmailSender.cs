using Microsoft.AspNetCore.Identity.UI.Services;

namespace CalorieCore.Services.Services
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
