using MediatR;
using WalletApp.Application.DTOs.PointDto;

namespace WalletApp.Application.Features.Points.Commands;

public class DeletePointCommand : IRequest<PointResponseDto>
{
    public Guid Id { get; set; }
}