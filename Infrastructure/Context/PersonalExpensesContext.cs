using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class PersonalExpensesContext : DbContext
{
    public PersonalExpensesContext()
    {
    }

    public PersonalExpensesContext(DbContextOptions<PersonalExpensesContext> options) : base(options)
    {
    }


    public DbSet<User> Users { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Expense> Expenses { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    // Configura todas las propiedades de tipo DateTime para que se mapeen como timestamp en PostgreSQL
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        foreach (var property in entityType.GetProperties())
        {
            if (property.ClrType == typeof(DateTime))
            {
                property.SetColumnType("timestamp");
            }
        }
    }
}
}