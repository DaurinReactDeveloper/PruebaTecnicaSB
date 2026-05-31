using GestorEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Persistence.Configurations
{
    public partial class EmployeeStatusConfiguration : IEntityTypeConfiguration<EmployeeStatus>
    {
        public void Configure(EntityTypeBuilder<EmployeeStatus> entity)
        {
            entity.HasKey(e => e.EmployeeStatusId).HasName("PK__Employee__360993CCCF8FC70C");

            entity.HasIndex(e => e.StatusName, "UQ__Employee__05E7698A93865E88").IsUnique();

            entity.Property(e => e.EmployeeStatusId).HasColumnName("EmployeeStatusID");
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
            entity.Property(e => e.StatusName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EmployeeStatus> entity);
    }
}
