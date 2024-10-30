using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var errorResult = new { error = "An error occured trying to process your request." };
        context.Result = new ObjectResult(errorResult) { StatusCode = 500 };
        context.HttpContext.Response.ContentType = "application/problem+json";
        context.ExceptionHandled = true;
    }
}
