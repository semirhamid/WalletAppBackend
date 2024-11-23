using FluentValidation;

namespace WalletApp.Application.DTOs.UserDto.Validators;

public class UpdateWalletUserDtoValidator : AbstractValidator<UpdateWalletUserDto>
{
    public UpdateWalletUserDtoValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First name is required.");

        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("Last name is required.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(user => user.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

        RuleFor(user => user.Address)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(user => user.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");
    }
}