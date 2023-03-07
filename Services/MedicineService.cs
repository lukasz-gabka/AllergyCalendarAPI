using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Models;
using AutoMapper;

namespace AllergyCalendarAPI.Services;

public class MedicineService
{
    private readonly ApiDbContext _dbContext;
    private readonly IMapper _mapper;

    public MedicineService(ApiDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public int Create(CreateMedicineDto dto)
    {
        var medicine = _mapper.Map<Medicine>(dto);
        _dbContext.Add(medicine);
        _dbContext.SaveChanges();

        return medicine.Id;
    }
}
