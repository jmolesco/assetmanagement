using AM.Core.Helper.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace AM.API.Validators
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorResponse error = GetError(context);

                context.Result = new BadRequestObjectResult(error);
            }
        }

        private static ErrorResponse GetError(ActionExecutingContext context)
        {
            var error = new ErrorResponse();
            var errorMessages = new List<object>();

            foreach (var modelState in context.ModelState.Values)
            {
                foreach (var modelError in modelState.Errors)
                {
                    errorMessages.Add(modelError.ErrorMessage);
                }
            }

            error.ErrorMessages = errorMessages;
            return error;
        }
    }
}
