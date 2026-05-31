using GestorEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Persistence.Configurations
{
    public partial class VwUserDetailConfiguration : IEntityTypeConfiguration<VwUserDetail>
    {
        public void Configure(EntityTypeBuilder<VwUserDetail> entity)
        {
            entity
                .HasNoKey()
                .ToView("vw_UserDetails");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeFullName)
                .IsRequired()
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeStatusId).HasColumnName("EmployeeStatusID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<VwUserDetail> entity);
    }
}
