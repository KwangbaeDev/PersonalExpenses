using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
{
    public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
    {
        builder
            .HasKey(ec => ec.Id)
            .HasName("ExpenseCategory_pkey");

        builder
            .Property(u => u.Name)
            .HasMaxLength(100);

        builder
            .Property(u => u.Description)
            .HasMaxLength(100);



        builder
            .HasOne(ec => ec.User)
            .WithMany(u => u.ExpenseCategories)
            .HasForeignKey(ec => ec.UserId);

        builder
            .HasMany(ec => ec.Expenses)
            .WithOne(e => e.ExpenseCategory)
            .HasForeignKey(e => e.ExpenseCategoryId);
    }
}