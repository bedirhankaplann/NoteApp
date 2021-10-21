using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NoteApp.Entities;
using NoteApp.WebApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApp.WebApiService.Filters
{
    public class NoteExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                HasError = true
            };
            response.Errors.Add("Find Error: " + context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
