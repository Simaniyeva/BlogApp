using System.Text.RegularExpressions;

namespace BusinessLogicLayer.Utilities.ValidationRules.FluentValidation.Register;

public class RegisterDtoValidation:AbstractValidator<RegisterDto>
{
    public RegisterDtoValidation()
    {
        RuleFor(p => p.FirstName).NotEmpty().WithMessage("First name is required.").NotNull().WithMessage("First name is required.")
            .Must(ValidName).WithMessage("First name is not valid!").MaximumLength(20).WithMessage("Try something short!")
            .MinimumLength(2).WithMessage("Write something longer!");
        RuleFor(p => p.LastName).NotEmpty().WithMessage("Last name is required.").NotNull().WithMessage("Last name is required.")
            .Must(ValidName).WithMessage("Last name is not valid!").MaximumLength(20).WithMessage("Try something short!")
            .MinimumLength(2).WithMessage("Write something longer!");
        RuleFor(dto => dto.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .NotNull().WithMessage("Username is required.")
            .Must(ValidUserName).WithMessage("Username is not valid!")
            .Length(4, 20).WithMessage("Username must be between 4 and 20 characters.");
        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .NotNull().WithMessage("Email is required.")
            //.Must(ValidEmail).WithMessage("Email is not valid!")
            .EmailAddress().WithMessage("Invalid email address.");
        RuleFor(dto => dto.Password)
            .NotEmpty().WithMessage("Password is required.")
            .NotNull().WithMessage("Password is required!")
            .MinimumLength(3).WithMessage("Password must be at least 3 characters.");
        RuleFor(dto => dto.ConfirmPassword)
            .NotEmpty().WithMessage("ConfirmPassword is required.")
            .NotNull().WithMessage("ConfirmPassword is required!")
            .Equal(x=>x.Password).WithMessage("Passwords are not same!")
            .MinimumLength(3).WithMessage("Confirm Password must be at least 3 characters.");
    }
    //Firstname and last name regex
    private bool ValidName(string name)
    {
        if (name is not null)
        {
            string nameRegex = @"^[A-Za-z]+(?:\s[A-Za-z]+)*$";
            Regex regex = new Regex(nameRegex);
            if (regex.IsMatch(name))
                return true;
        }
        return false;
    }
    //userName regex
    private bool ValidUserName(string userName)
    {
        if (userName is not null)
        {
            string nameRegex = @"^[a-zA-Z0-9_-]+$";
            Regex regex = new Regex(nameRegex);
            if (regex.IsMatch(userName))
                return true;
        }
        return false;
    }

    //private bool ValidEmail(string email)
    //{
    //    if (email is not null)
    //    {
    //        string emailRegex = @"^([a-zA-Z0-9]+([\\._\\-]{1})?){1,}[\\w]\\@{1}([a-zA-Z]+([\\.]{1})?){1,}([a-zA-Z])\\.[a-zA-Z]+$";
    //        Regex regex = new Regex(emailRegex);
    //        if (regex.IsMatch(email))
    //            return true;
    //    }
    //    return false;
    //}
}
