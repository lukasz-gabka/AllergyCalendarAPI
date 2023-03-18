using AllergyCalendarAPI.Models;
using AllergyCalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCalendarAPI.Controllers;

[Route("[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpPut]
    public ActionResult Register(RegisterUserDto dto)
    {
        _service.Register(dto);


        return NoContent();
    }
}
