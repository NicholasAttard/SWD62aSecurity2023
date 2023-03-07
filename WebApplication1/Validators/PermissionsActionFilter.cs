using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Validators
{
    public class PermissionsActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //I need to check wether the ISBN being input is in the table permissions realted with the logged user
            string id  = context.HttpContext.User.Claims.ElementAt(0).Value;
            string isbn = context.HttpContext.Request.Form.ElementAt(0).Value;
        }
    }
}
