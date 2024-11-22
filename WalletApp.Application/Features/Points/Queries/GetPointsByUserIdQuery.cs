using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Queries;

public class GetPointsByUserIdQuery : IRequest<IEnumerable<PointDto>>
{
    public Guid UserId { get; set; }
}