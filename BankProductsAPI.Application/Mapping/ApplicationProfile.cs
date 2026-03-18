// BankProductsAPI/Application/Mapping/ApplicationProfile.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Application;

namespace BankProductsAPI.Application.Mapping
{
    /// <summary>
    /// Класс, обеспечивающий перезалив данных из ApplicationDto в Application и наоборот.
    /// </summary>
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile() 
        {
            // Application -> ApplicationDto (когда отдаём данные клиенту)
            CreateMap<Domain.Entities.Application, ApplicationDto>();

            // CreateApplicationDto -> Application (когда создаём клиента из входных данных)
            CreateMap<CreateApplicationDto, Domain.Entities.Application>();
        }

    }
}
