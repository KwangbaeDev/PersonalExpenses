using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();
        services.AddServices();
        services.AddValidation();

        return services;
    }


    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PersonalExpense");

        services.AddDbContext<PersonalExpensesContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }


    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        return services;
    }


    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}