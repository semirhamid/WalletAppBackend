using System.Transactions;
using AutoMapper;
using WalletApp.Application.DTOs.TransactionDTOs;

namespace WalletApp.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
        }
    }
}