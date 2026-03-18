// BankProductsAPI/Application/Mapping/DepositProfile.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Deposit;
using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Mapping
{
    /// <summary>
    /// Класс, обеспечивающий перезалив данных из DepositDto в Deposit и наоборот.
    /// </summary>
    public class DepositProfile : Profile
    {
        public DepositProfile()
        {
            // Deposit -> DepositDto (когда отдаём данные клиенту)
            CreateMap<Deposit, DepositDto>();

            // DepositDto -> Deposit (когда создаём клиента из входных данных)
            CreateMap<CreateDepositDto, Deposit>();
        }
    }
}
