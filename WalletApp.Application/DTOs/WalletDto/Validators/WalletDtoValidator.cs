using FluentValidation;

namespace WalletApp.Application.DTOs.WalletDto.Validators;

public class WalletDtoValidator : AbstractValidator<CreateWalletDto>
{
    public WalletDtoValidator()
    {
        RuleFor(wallet => wallet.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(wallet => wallet.CurrentBalance)
            .GreaterThanOrEqualTo(0).WithMessage("Current balance must be greater than or equal to zero.");

        RuleFor(wallet => wallet.TotalPoints)
            .GreaterThanOrEqualTo(0).WithMessage("Total points must be greater than or equal to zero.");
    }
}