using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCalendarAPI.Controllers;

[Route("[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApiDbContext _dbContext;
    private readonly UserService _service;

    public UserController(ApiDbContext dbContext, UserService service)
    {
        _dbContext = dbContext;
        _service = service;
    }

    [HttpPut]
    public ActionResult Register(RegisterUserDto dto)
    {
        _service.Register(dto);


        return NoContent();
    }
}
