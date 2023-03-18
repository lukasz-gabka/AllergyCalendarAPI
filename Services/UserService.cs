using AllergyCalendarAPI.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AllergyCalendarAPI.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _hasher;
    private readonly ApiDbContext _dbContext;

    public UserService(IMapper mapper, IPasswordHasher<User> hasher, ApiDbContext context)
    {
        _mapper = mapper;
        _hasher = hasher;
        _dbContext = context;

    }

    public void Register(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var passwordHash = _hasher.HashPassword(user, dto.Password);
        user.PasswordHash = passwordHash;

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}
