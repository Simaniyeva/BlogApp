using System.Text.RegularExpressions;

namespace BusinessLogicLayer.Utilities.ValidationRules.FluentValidation.Role;

public class RolePostDtoValidation: AbstractValidator<RolePostDto>
{
    public RolePostDtoValidation()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role must be name!").NotNull().WithMessage("Role must be name!")
            .Must(ValidName).WithMessage("Name is not valid!").MaximumLength(255).WithMessage("Try something short!")
            .MinimumLength(2).WithMessage("Write something longer!");
    }

    private bool ValidName(string name)
    {
        if (name is not null)
        {
            string nameRegex = @"^[A-ZƏŞÇĞÜÖI]+[a-zA-ZəƏŞşÇçĞğÜüÖöIı']*(?:[\s-]+[A-ZƏŞÇĞÜÖI]+[a-zA-ZəƏŞşÇçĞğÜüÖöIı']*(?:[.,!?;:'-]+[A-ZƏŞÇĞÜÖI]+[a-zA-ZəƏŞşÇçĞğÜüÖöIı']*)?)*[.,!?;:'-]*$";
            Regex regex = new Regex(nameRegex);
            if (regex.IsMatch(name))
                return true;
        }
        return false;
    }

}