using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NoteApp.Entities;
using NoteApp.WebApiService.Models;

namespace NoteApp.WebApiService.Filters
{
    public class CategoryExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                HasError = true
            };
            response.Errors.Add("Find Error: " + context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
