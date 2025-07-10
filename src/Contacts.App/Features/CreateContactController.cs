using Contacts.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.App.Features;

[ApiController]
[Route("api/[controller]")]
public class CreateContactController : ControllerBase
{


    private readonly IContactService _contactService;

    public CreateContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactRequest request)
    {
        try
        {
            await _contactService.CreateAsync(request.Name, request.Email, request.PhoneNumber);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
    }

}