using FluentValidation;

namespace WalletApp.Application.DTOs.PointDto.Validators;

public class PointDtoValidator : AbstractValidator<PointDto>
{
    public PointDtoValidator()
    {

        RuleFor(point => point.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(point => point.PointValue)
            .GreaterThan(0).WithMessage("Points must be greater than zero.");
    }
}