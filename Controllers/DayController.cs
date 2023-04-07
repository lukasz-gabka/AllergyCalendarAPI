using AllergyCalendarAPI.Models;
using AllergyCalendarAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCalendarAPI.Controllers;

[Route("[Controller]")]
[ApiController]
[Authorize]
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

    [HttpGet]
    public ActionResult<DayDto> Get()
    {
        var dtoList = _service.Get();
        if (dtoList is null || dtoList.Count() == 0)
        {
            return NoContent();
        }
        return Ok(dtoList);
    }

    [HttpPut]
    public ActionResult Update(UpdateDayDto dto)
    {
        var isUpdated = _service.Update(dto);
        if (!isUpdated)
        {
            return NotFound();
        }
        return NoContent();
    }
}
