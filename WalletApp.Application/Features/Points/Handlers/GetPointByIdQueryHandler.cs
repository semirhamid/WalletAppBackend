using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.Features.Points.Queries;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.Points.Handlers;

public class GetPointsByIdQueryHandler : IRequestHandler<GetPointByIdQuery, PointResponseDto>
{
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;

    public GetPointsByIdQueryHandler(IPointRepository pointRepository, IMapper mapper)
    {
        _pointRepository = pointRepository;
        _mapper = mapper;
    }

    public async Task<PointResponseDto> Handle(GetPointByIdQuery request, CancellationToken cancellationToken)
    {
        var point = await _pointRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<PointResponseDto>(point);
    }
}