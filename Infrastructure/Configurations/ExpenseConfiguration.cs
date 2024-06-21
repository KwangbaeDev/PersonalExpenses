using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("Expense_pkey");

        builder
            .Property(u => u.Amount)
            .HasColumnType("decimal(18,2)");

        builder
            .Property(u => u.ExpenseDatetime);

        builder
            .Property(u => u.Description)
            .HasMaxLength(100);



        builder
            .HasOne(e => e.ExpenseCategory)
            .WithMany(ec => ec.Expenses)
            .HasForeignKey(ec => ec.ExpenseCategoryId);
    }
}