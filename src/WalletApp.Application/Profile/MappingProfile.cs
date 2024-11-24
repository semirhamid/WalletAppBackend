using AutoMapper;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Domain.Entities;

namespace WalletApp.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WalletUser, WalletUserResponseDto>().ReverseMap();
            CreateMap<CreateWalletUserDto, WalletUser>().ReverseMap();
            
            CreateMap<CreateWalletDto, Wallet>();
            CreateMap<WalletResponseDto, Wallet>().ReverseMap();
            
            CreateMap<Transaction, UpdateTransationDto>().ReverseMap();
            CreateMap<TransactionResponseDto, Transaction>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.WalletUserId));
            
            CreateMap<Transaction, TransactionResponseDto>()
                .ForMember(dest => dest.WalletUserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<CreateTransactionDto, Transaction>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
                    src.Amount >= 0
                        ? TransactionType.Credit
                        : TransactionType.Payment))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src =>
                    src.IsPending
                        ? TransationStatus.Pending
                        : TransationStatus.Authorized))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.WalletUserId));
            
            
            CreateMap<Point, PointResponseDto>().ReverseMap();
            CreateMap<CreatePointDto, PointResponseDto>().ReverseMap();
            CreateMap<Point, CreatePointDto>().ReverseMap();
            CreateMap<Point, UpdatePointDto>().ReverseMap();
            
        }
    }
}