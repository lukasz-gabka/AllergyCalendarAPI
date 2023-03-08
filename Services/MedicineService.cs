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

    public bool Delete(int id)
    {
        var medicine = _dbContext.Medicines     
            .Where(m => m.Id == id)
            .SingleOrDefault();

        if (medicine is null)
        {
            return false;
        }

        _dbContext.Remove(medicine);
        _dbContext.SaveChanges();

        return true;
    }

    public IEnumerable<MedicineDto> Get()
    {
        var medicines = _dbContext.Medicines.ToList();
        var dtoList = _mapper.Map<List<MedicineDto>>(medicines);

        return dtoList;
    }

    public bool Update(MedicineDto dto)
    {
        var medicine = _dbContext.Medicines
            .Where(m => m.Id == dto.Id)
            .SingleOrDefault();

        if (medicine is null)
        {
            return false;
        }

        medicine.Name = dto.Name;
        _dbContext.SaveChanges();

        return true;
    }
}
