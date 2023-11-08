using System.Text.RegularExpressions;

namespace BusinessLogicLayer.Utilities.ValidationRules.FluentValidation.Tag;

public class TagPostDtoValidation:AbstractValidator<TagPostDto>
{
    public TagPostDtoValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Tag must be a name!").NotNull().WithMessage("Tag must be a name")
            .MinimumLength(2).WithMessage("Write something longer!").MaximumLength(50)
                .WithMessage("Try something short!")
                    .Must(ValidName).WithMessage("Name is not valid!");
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