using AllergyCalendarAPI.Models;
using AllergyCalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCalendarAPI.Controllers;

[Route("[Controller]")]
[ApiController]
public class DayController : ControllerBase
{
    private readonly DayService _service;

    public DayController(DayService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public ActionResult Create([FromBody] CreateDayDto dto)
    {
        var id = _service.Create(dto);
        return Created($"day/{id}", id);
    }
}
