// BankProductsAPI/Application/Mapping/CreditProfile.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Credit;
using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Mapping
{
    /// <summary>
    /// Класс, обеспечивающий перезалив данных из CreditDto в Credit и наоборот.
    /// </summary>
    public class CreditProfile : Profile
    {
        public CreditProfile() 
        {
            // Credit -> CreditDto (когда отдаём данные клиенту)
            CreateMap<Credit, CreditDto>();

            // CreditDto -> Credit (когда создаём клиента из входных данных)
            CreateMap<CreateCreditDto, Credit>();
        }
    }
}
