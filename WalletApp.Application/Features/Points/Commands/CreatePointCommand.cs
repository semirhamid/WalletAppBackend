using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Commands;

public class CreatePointCommand : IRequest<PointDto>
{
    public Guid UserId { get; set; }
    public int Points { get; set; }
}