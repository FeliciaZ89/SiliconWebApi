
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(ApiContext context) : ControllerBase


{
    private readonly ApiContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(string email)
    {
        if (ModelState.IsValid)
        {
            if (await _context.Subscribes.AnyAsync(x => x.Email == email))
                return Conflict();

            _context.Add(new SubscribersEntity { Email = email });
            await _context.SaveChangesAsync();
            return Ok();

        }


        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        if (ModelState.IsValid)
        {

            var subscribersEntity = await _context.Subscribes.FirstOrDefaultAsync(x => x.Email == email);
            if (subscribersEntity == null)
                return NotFound();

            _context.Remove(subscribersEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }


        return BadRequest();
    }
}
