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
        var validationResult = await _validator.ValidateAsync(request.Transation, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var transaction = _mapper.Map<Transaction>(request);
        await _transactionRepository.UpdateAsync(transaction, cancellationToken);
        return Unit.Value;
    }
}