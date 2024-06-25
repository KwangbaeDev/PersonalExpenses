using Core.Entities;
using Core.Models.ExpenseDTOs;
using Core.Request.ExpenseModels;
using Mapster;

namespace Infrastructure.Mappings;

public class ExpenseMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Del Create a la Entidad
        config.NewConfig<CreateExpenseModel, Expense>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.ExpenseDatetime, src => DateTime.Now)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.ExpenseCategoryId, src => src.ExpenseCategoryId);


        // De la Entidad al DTO
        config.NewConfig<Expense, ExpenseDTO>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Amount, src => src.Amount)
            .Map(dest => dest.ExpenseDatetime, src => src.ExpenseDatetime)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.ExpenseCategory, src => src.ExpenseCategory);
    }
}