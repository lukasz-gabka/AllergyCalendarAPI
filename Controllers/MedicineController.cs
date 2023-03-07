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
}
