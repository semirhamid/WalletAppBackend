﻿using AutoMapper;
using MediatR;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.Features.Points.Queries;
using WalletApp.Application.Contracts.Persistence;

namespace WalletApp.Application.Features.Points.Handlers;

public class GetPointsByUserIdQueryHandler : IRequestHandler<GetPointsByUserIdQuery, IEnumerable<PointResponseDto>>
{
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;

    public GetPointsByUserIdQueryHandler(IPointRepository pointRepository, IMapper mapper)
    {
        _pointRepository = pointRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PointResponseDto>> Handle(GetPointsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var points = await _pointRepository.GetPointsByUserIdAsync(request.UserId, cancellationToken);
        return _mapper.Map<IEnumerable<PointResponseDto>>(points);
    }
}