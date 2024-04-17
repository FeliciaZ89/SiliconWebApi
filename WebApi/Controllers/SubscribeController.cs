
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController : ControllerBase
{
    public async Task<IActionResult> Subscribe()
    {
        return Ok();
    }

    public async Task<IActionResult> Unsubscribe()
    {
        return Ok();
    }
}
