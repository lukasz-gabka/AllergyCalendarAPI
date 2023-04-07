using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Models;
using AutoMapper;

namespace AllergyCalendarAPI.Services;

public class SymptomService
{
    private readonly ApiDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly UserContextService _userContextService;

    public SymptomService(ApiDbContext dbContext, IMapper mapper, UserContextService userContextService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _userContextService = userContextService;
    }

    public int Create(CreateSymptomDto dto)
    {
        var symptom = _mapper.Map<Symptom>(dto);
        symptom.UserId = _userContextService.GetUserId;

        _dbContext.Add(symptom);
        _dbContext.SaveChanges();

        return symptom.Id;
    }

    public bool Delete(int id)
    {
        var symptom = _dbContext.Symptoms     
            .Where(s => s.Id == id)
            .Where(s => s.UserId == _userContextService.GetUserId)
            .SingleOrDefault();

        if (symptom is null)
        {
            return false;
        }

        _dbContext.Remove(symptom);
        _dbContext.SaveChanges();

        return true;
    }

    public IEnumerable<SymptomDto> Get()
    {
        var symptoms = _dbContext.Symptoms
            .Where(s => s.UserId == _userContextService.GetUserId)
            .ToList();
        var dtoList = _mapper.Map<List<SymptomDto>>(symptoms);

        return dtoList;
    }

    public bool Update(SymptomDto dto)
    {
        var symptom = _dbContext.Symptoms
            .Where(s => s.Id == dto.Id)
            .Where(s => s.UserId == _userContextService.GetUserId)
            .SingleOrDefault();

        if (symptom is null)
        {
            return false;
        }

        symptom.Name = dto.Name;
        _dbContext.SaveChanges();

        return true;
    }
}
