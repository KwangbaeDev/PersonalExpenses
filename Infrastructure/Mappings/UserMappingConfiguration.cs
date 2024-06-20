using Core.Entities;
using Core.Models;
using Core.Request;
using Mapster;

namespace Infrastructure.Mapping;

public class UserMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Del Creation object hacia la entidad
        config.NewConfig<CreateUserModel, User>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.CreationDateTime, src => DateTime.Now)
            .Map(dest => dest.UpdatedDatetime, src => DateTime.Now);


        //Entidad hacia el DTO
        config.NewConfig<User, UserDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.CreationDateTime, src => src.CreationDateTime)
            .Map(dest => dest.UpdatedDatetime, src => src.UpdatedDatetime);
    }
}