using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.DTOs.PointDto.Validators;
using WalletApp.Application.Features.Points.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;
using ValidationException = WalletApp.Application.Exceptions.ValidationException;

namespace WalletApp.Application.Features.Points.Handlers;

public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, PointResponseDto>
{
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;
    private readonly IWalletUserRepository _walletUserRepository;
    private readonly IValidator<CreatePointDto> _validator;

    public CreatePointCommandHandler(IPointRepository pointRepository, IMapper mapper, IWalletUserRepository walletUserRepository, IValidator<CreatePointDto> validator)
    {
        _pointRepository = pointRepository;
        _mapper = mapper;
        _walletUserRepository = walletUserRepository;
        _validator = validator;
    }

    public async Task<PointResponseDto> Handle(CreatePointCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Point, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var user = await _walletUserRepository.GetByIdAsync(request.Point.UserId, cancellationToken);
        if (user == null)
        {
            throw new ApplicationException($"User with id {request.Point.UserId} not found");
        }
        

        await _pointRepository.AddAsync(_mapper.Map<Point>(request.Point), cancellationToken);
        return _mapper.Map<PointResponseDto>(request.Point);
    }
}