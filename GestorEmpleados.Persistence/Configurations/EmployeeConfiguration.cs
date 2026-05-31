using GestorEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Persistence.Configurations
{
    public partial class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF12F9DCE08");

            entity.HasIndex(e => e.SocialSecurityNumber, "UQ__Employee__2EFDFD396CC68562").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.BaseSalary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CommissionRate).HasColumnType("decimal(4, 2)");
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
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.EmployeeStatusId)
                .HasDefaultValue(1)
                .HasColumnName("EmployeeStatusID");
            entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GrossSales).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HoursWorked).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SocialSecurityNumber)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.WeeklySalary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Departments");

            entity.HasOne(d => d.EmployeeStatus).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_EmployeeStatuses");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_EmployeeTypes");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Employee> entity);
    }
}
