using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.Features.Transactions.Commands;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Domain.Entities;
using ValidationException = WalletApp.Application.Exceptions.ValidationException;

namespace WalletApp.Application.Features.Transactions.Handlers;
public class UpdateTransactionHandler : IRequestHandler<UpdateTransactionCommand>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateTransationDto> _validator;

    public UpdateTransactionHandler(ITransactionRepository transactionRepository, IMapper mapper, IValidator<UpdateTransationDto> validator)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Transaction, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var existingTransaction = await _transactionRepository.GetByIdAsync(request.Transaction.Id, cancellationToken);
        if (existingTransaction == null)
        {
            throw new KeyNotFoundException($"Transaction with ID {request.Transaction.Id} not found.");
        }

        existingTransaction.Name = request.Transaction.Name;
        existingTransaction.Amount = request.Transaction.Amount;
        existingTransaction.Date = request.Transaction.Date;
        existingTransaction.Type = request.Transaction.Amount >= 0 ? TransactionType.Credit : TransactionType.Payment;
        existingTransaction.Status = request.Transaction.IsPending ? TransationStatus.Pending : TransationStatus.Authorized;
        await _transactionRepository.UpdateAsync(existingTransaction, cancellationToken);

        return Unit.Value;
    }
}
