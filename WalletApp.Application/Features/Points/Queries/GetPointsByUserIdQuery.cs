using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Queries;

public class GetPointsByUserIdQuery : IRequest<IEnumerable<PointResponseDto>>
{
    public Guid UserId { get; set; }
}