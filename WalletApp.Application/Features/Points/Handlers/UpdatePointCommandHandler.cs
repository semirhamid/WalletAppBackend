using AutoMapper;
using FluentValidation;
using MediatR;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.DTOs.PointDto.Validators;
using WalletApp.Application.Features.Points.Commands;
using WalletApp.Application.Contracts.Persistence;
using WalletApp.Application.Exceptions;
using WalletApp.Domain.Entities;
using ValidationException = WalletApp.Application.Exceptions.ValidationException;

namespace WalletApp.Application.Features.Points.Handlers;

public class UpdatePointCommandHandler : IRequestHandler<UpdatePointCommand, PointResponseDto>
{
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;
    private readonly IWalletUserRepository _walletUserRepository;
    private readonly IValidator<UpdatePointDto> _validator;

    public UpdatePointCommandHandler(IPointRepository pointRepository, IMapper mapper, IWalletUserRepository walletUserRepository, IValidator<UpdatePointDto> validator)
    {
        _pointRepository = pointRepository;
        _mapper = mapper;
        _walletUserRepository = walletUserRepository;
        _validator = validator;
    }

    public async Task<PointResponseDto> Handle(UpdatePointCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Point, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var user = await _walletUserRepository.GetByIdAsync(request.Point.UserId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("User", request.Point.UserId);
        }
        var point = await _pointRepository.GetByIdAsync(request.Point.Id, cancellationToken);
        if (point == null)
        {
            throw new NotFoundException("Point", request.Point.Id);
        }
        point.PointValue = request.Point.PointValue;
        await _pointRepository.UpdateAsync(point, cancellationToken);
        return _mapper.Map<PointResponseDto>(request.Point);
    }
}