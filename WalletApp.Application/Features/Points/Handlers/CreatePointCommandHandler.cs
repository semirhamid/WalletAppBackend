using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.Features.Points.Commands;
using WalletApp.Application.Persistence.Contract;
using WalletApp.Domain.Entities;

namespace WalletApp.Application.Features.Points.Handlers;

public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, PointDto>
{
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;
    private readonly IWalletUserRepository _walletUserRepository;
    public CreatePointCommandHandler(IPointRepository pointRepository, IMapper mapper, IWalletUserRepository walletUserRepository)
    {
        _pointRepository = pointRepository;
        _mapper = mapper;
        _walletUserRepository = walletUserRepository;
    }

    public async Task<PointDto> Handle(CreatePointCommand request, CancellationToken cancellationToken)
    {
        var user = await _walletUserRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new ApplicationException($"User with id {request.UserId} not found");
        }
        

        await _pointRepository.AddAsync(_mapper.Map<PointDto>(request), cancellationToken);
        return _mapper.Map<PointDto>(request);
    }
}