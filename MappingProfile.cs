using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Models;
using AutoMapper;

namespace AllergyCalendarAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateMedicineDto, Medicine>();
        CreateMap<Medicine, MedicineDto>().ReverseMap();

        CreateMap<CreateSymptomDto, Symptom>();
        CreateMap<Symptom, SymptomDto>().ReverseMap();

        CreateMap<Day, DayDto>().ReverseMap();

        CreateMap<RegisterUserDto, User>();
    }
}
