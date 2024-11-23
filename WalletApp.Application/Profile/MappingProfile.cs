using AutoMapper;
using WalletApp.Application.DTOs.PointDto;
using WalletApp.Application.DTOs.TransactionDTOs;
using WalletApp.Application.DTOs.UserDto;
using WalletApp.Application.DTOs.WalletDto;
using WalletApp.Domain.Entities;
using Transaction = System.Transactions.Transaction;

namespace WalletApp.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WalletUser, WalletUserResponseDto>().ReverseMap();
            CreateMap<CreateWalletDto, Wallet>();
            CreateMap<WalletResponseDto, Wallet>().ReverseMap();
            CreateMap<Transaction, TransactionResponseDto>().ReverseMap();
            CreateMap<Point, PointResponseDto>().ReverseMap();
            CreateMap<Point, UpdatePointDto>().ReverseMap();
            
        }
    }
}