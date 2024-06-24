using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;
using Core.Request;
using Mapster;

namespace Infrastructure.Mappings
{
    public class ExpenseCategoryMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //Del Creation object hacia la entidad
            config.NewConfig<CreateExpenseCategoryModel, ExpenseCategory>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.UserId, src => src.UserId);



            //De la Entidad al DTO
            config.NewConfig<ExpenseCategory, ExpenseCategoryDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.User, src => src.User);
        }
    }
}