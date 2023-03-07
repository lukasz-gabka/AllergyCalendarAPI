using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Models;
using AutoMapper;

namespace AllergyCalendarAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateMedicineDto, Medicine>();
    }
}
