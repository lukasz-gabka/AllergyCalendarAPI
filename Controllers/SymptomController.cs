using AllergyCalendarAPI.Models;
using AllergyCalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCalendarAPI.Controllers;

[Route("[Controller]")]
[ApiController]
public class SymptomController : ControllerBase
{
    private readonly SymptomService _service;

    public SymptomController(SymptomService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult Create([FromBody] CreateSymptomDto dto)
    {
        var id = _service.Create(dto);
        return Created($"symptom/{id}", id);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _service.Delete(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet]
    public ActionResult<IEnumerable<SymptomDto>> Get()
    {
        var dtoList = _service.Get();
        if (dtoList == null || dtoList.Count() == 0)
        {
            return NoContent();
        }
        return Ok(dtoList);
    }

    [HttpPut]
    public ActionResult Update([FromBody] SymptomDto dto)
    {
        var isUpdated = _service.Update(dto);
        if (!isUpdated)
        {
            return NotFound();
        }
        return NoContent();
    }
}
