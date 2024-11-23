using FluentValidation;

namespace WalletApp.Application.DTOs.PointDto.Validators;

public class UpdatePointDtoValidator : AbstractValidator<UpdatePointDto>
{
    public UpdatePointDtoValidator()
    {
        RuleFor(point => point.Id)
            .NotEmpty().WithMessage("Point Id is required.");

        RuleFor(point => point.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(point => point.PointValue)
            .GreaterThan(0).WithMessage("Points must be greater than zero.");
        
        RuleFor(point=>point.Date)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Point date must be greater than now");
    }
}