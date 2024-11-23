using FluentValidation;

namespace WalletApp.Application.DTOs.TransactionDTOs.Validators;

public class CreateTransationDtoValidator : AbstractValidator<CreateTransactionDto>
{
    public CreateTransationDtoValidator()
    {
        RuleFor(transaction => transaction.WalletUserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(transaction => transaction.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(transaction => transaction.Name)
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(transaction => transaction.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(transaction => transaction.Date)
            .NotEmpty().WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Date cannot be in the future.");

        RuleFor(transaction => transaction.Type)
            .NotEmpty().WithMessage("Type is required.");

        RuleFor(transaction => transaction.IsPending)
            .NotNull().WithMessage("IsPending status is required.");
    }
}