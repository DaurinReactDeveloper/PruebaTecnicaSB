using GestorEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Persistence.Configurations
{
    public partial class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> entity)
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("PK__Employee__1F1B6AB4DEB6A3AC");

            entity.HasIndex(e => e.TypeName, "UQ__Employee__D4E7DFA8197A2E3A").IsUnique();

            entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");
            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TypeName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EmployeeType> entity);
    }
}
