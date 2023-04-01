using AllergyCalendarAPI.Entities;
using AllergyCalendarAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AllergyCalendarAPI.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _hasher;
    private readonly ApiDbContext _dbContext;
    private readonly TokenService _service;

    public UserService(IMapper mapper, IPasswordHasher<User> hasher, ApiDbContext context, TokenService service)
    {
        _mapper = mapper;
        _hasher = hasher;
        _dbContext = context;
        _service = service;
    }

    public void Register(RegisterUserDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var passwordHash = _hasher.HashPassword(user, dto.Password);
        user.PasswordHash = passwordHash;

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public string Login(LoginUserDto dto)
    {
        var user = _dbContext.Users
            .SingleOrDefault(u => u.Email == dto.Email);

        if (user == null)
        {
            throw new Exception("Invalid email or password");
        }

        var passwordHash = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

        if (passwordHash == PasswordVerificationResult.Failed)
        {
            throw new Exception("Invalid email or password");
        }

        var token = _service.GenerateToken(user);
        
        return token;
    }
}
