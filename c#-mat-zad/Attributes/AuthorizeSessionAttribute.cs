using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace c__mat_zad.Attributes
{
    public class AuthorizeSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
