using FluentValidation;

namespace WalletApp.Application.DTOs.PointDto.Validators;

public class CreatePointDtoValidator : AbstractValidator<CreatePointDto>
{
    public CreatePointDtoValidator()
    {

        RuleFor(point => point.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(point => point.PointValue)
            .GreaterThan(0).WithMessage("Points must be greater than zero.");
    }
}