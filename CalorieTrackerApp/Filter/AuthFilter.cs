using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class AuthFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var http = context.HttpContext;
        var path = http.Request.Path.Value?.ToLower();

        bool loggedIn = http.Session.GetString("Username") != null;

        bool allowed =
       path == "/" ||
       path.Contains("/home") ||
       path.Contains("/privacy") ||
       path.Contains("/account/login") ||
       path.Contains("/account/register");


        if (!loggedIn && !allowed)
        {
            context.Result = new RedirectToActionResult("Login", "Account", null);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
