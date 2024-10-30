using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[Route("error")]
public class ErrorController : ControllerBase
{
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
        string? type = null;
        string? detail = null;
        string? instance = null;

        return Problem();
    }
}
