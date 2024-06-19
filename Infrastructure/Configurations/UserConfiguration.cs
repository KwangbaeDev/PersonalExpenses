using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {   
        builder
            .HasKey(u => u.Id)
            .HasName("Account_pkey");

        builder
            .Property(u => u.Name)
            .HasMaxLength(100);

        builder
            .Property(u => u.Email)
            .HasMaxLength(100);

        builder
            .Property(u => u.Password)
            .HasMaxLength(100);

        builder
            .Property(u => u.CreationDateTime);

        builder
            .Property(u => u.UpdatedDatetime);
    }
}