// BankProductsAPI/Application/Mapping/ClientProfile.cs


using AutoMapper;
using BankProductsAPI.Application.DTOs.Client;
using BankProductsAPI.Domain.Entities;

namespace BankProductsAPI.Application.Mapping
{
    /// <summary>
    /// Класс, обеспечивающий перезалив данных из ClientDto в Client и наоборот.
    /// </summary>
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            // Client -> ClientDto (когда отдаём данные клиенту)
            CreateMap<Client, ClientDto>();

            // CreateClientDto -> Client (когда создаём клиента из входных данных)
            CreateMap<CreateClientDto, Client>();
        }
    }
}
