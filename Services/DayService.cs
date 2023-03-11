﻿using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Models;
using AutoMapper;

namespace AllergyCalendarAPI.Services;

public class DayService
{
    private ApiDbContext _dbContext;
    private readonly IMapper _mapper;

    public DayService(ApiDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public int Create(CreateDayDto dto)
    {
        var medicine = _dbContext.Medicines
            .Where(m => m.Id == dto.MedicineId)
            .SingleOrDefault();

        var symptoms = _dbContext.Symptoms
            .Where(s => dto.SymptomIds.Contains(s.Id))
            .ToList();

        var day = new Day()
        {
            Date = dto.Date,
            MedicineId = medicine.Id,
            Medicine = medicine,
            Symptoms = symptoms
        };

        _dbContext.Add(day);
        _dbContext.SaveChanges();

        return day.Id;
    }
}
