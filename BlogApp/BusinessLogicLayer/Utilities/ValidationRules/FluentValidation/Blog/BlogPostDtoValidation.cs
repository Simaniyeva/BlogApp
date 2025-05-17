using System.Text.RegularExpressions;

namespace BusinessLogicLayer.Utilities.ValidationRules.FluentValidation.Blog;

public class BlogPostDtoValidation : AbstractValidator<BlogPostDto>
{
    public BlogPostDtoValidation()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Blog must be title!").NotNull().WithMessage("Blog must be title!")
            .MaximumLength(255).WithMessage("Try something short!")
                .MinimumLength(2).WithMessage("Write something longer!");
        RuleFor(p => p.Description).NotNull().WithMessage("Blog must be description!").NotEmpty()
            .WithMessage("Blog must be description!").MinimumLength(10).WithMessage("Write something longer!")
                .WithMessage("Try something short!");
        RuleFor(p => p.ReadingTime).NotEmpty().WithMessage("Blog must be a Reading Time").NotNull()
            .WithMessage("Blog must be a Reading Time").LessThan(30).WithMessage("Try something smaller!")
                .GreaterThanOrEqualTo(0).WithMessage("Try something larger!"); ; ;
        RuleFor(p => p.formFiles).NotNull().WithMessage("Blog must be image!").NotEmpty().WithMessage("Blog must be image!");
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