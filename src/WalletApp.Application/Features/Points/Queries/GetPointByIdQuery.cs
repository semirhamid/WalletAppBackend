using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Queries;

public class GetPointByIdQuery : IRequest<PointResponseDto>
{
    public Guid Id { get; set; }
}