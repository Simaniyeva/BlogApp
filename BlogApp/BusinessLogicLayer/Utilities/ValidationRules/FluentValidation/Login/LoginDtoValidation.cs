namespace BusinessLogicLayer.Utilities.ValidationRules.FluentValidation.Login;

public class LoginDtoValidation:AbstractValidator<LoginDto>
{
    public LoginDtoValidation()
    {
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .NotNull().WithMessage("Email is required");


        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage("Password is required.")
            .NotNull().WithMessage("Password is required.");

    }
}