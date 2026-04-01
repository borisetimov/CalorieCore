using Microsoft.AspNetCore.Identity.UI.Services;
//This method is used ny Identity framework to send emails for password resets, email confirmations, etc. Since we are not implementing actual email sending functionality, this is a dummy implementation that does nothing.
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
