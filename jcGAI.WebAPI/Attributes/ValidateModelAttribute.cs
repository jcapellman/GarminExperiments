using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace jcGAI.WebAPI.Attributes
{
    public class ValidateModelFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
             
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var modelStateErrors = context.ModelState.Values.SelectMany(a => a.Errors).ToList().Select(a => a.ErrorMessage).ToList();

            var errors = string.Join(' ', modelStateErrors);

            context.Result = new BadRequestObjectResult(errors);
        }
    }
}