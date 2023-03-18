using AllergyCalendarAPI.Entities;
using FluentValidation;

namespace AllergyCalendarAPI.Models;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator(ApiDbContext dbContext)
    {
        RuleFor(r => r.Email)
            .Custom((value, context) =>
            {
                var isEmailUsed = dbContext.Users.Any(u => u.Email == value);
                if (isEmailUsed)
                {
                    context.AddFailure("Email", "The email is in use");
                }
            });

        RuleFor(r => r.Password).Equal(r => r.ConfirmPassword)
            .WithMessage("The passwords are not the same");
    }
}
