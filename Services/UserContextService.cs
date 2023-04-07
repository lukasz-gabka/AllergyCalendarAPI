using System.Security.Claims;

namespace AllergyCalendarAPI.Services;

public class UserContextService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserContextService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public ClaimsPrincipal? User => _contextAccessor.HttpContext?.User;

    public int? GetUserId => User is null ? null : Convert.ToInt32(
        User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
}
