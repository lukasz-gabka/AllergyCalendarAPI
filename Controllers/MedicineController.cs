using AllergyCalendarAPI.Models;
using AllergyCalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCalendarAPI.Controllers;

[Route("[Controller]")]
[ApiController]
public class MedicineController : ControllerBase
{
    private readonly MedicineService _service;

    public MedicineController(MedicineService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult Create([FromBody] CreateMedicineDto dto)
    {
        var id = _service.Create(dto);
        return Created($"medicine/{id}", id);
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
    public ActionResult<IEnumerable<MedicineDto>> Get()
    {
        var dtoList = _service.Get();
        if (dtoList == null || dtoList.Count() == 0)
        {
            return NoContent();
        }
        return Ok(dtoList);
    }

    [HttpPut]
    public ActionResult Update([FromBody] MedicineDto dto)
    {
        var isUpdated = _service.Update(dto);
        if (!isUpdated)
        {
            return NotFound();
        }
        return NoContent();
    }
}
