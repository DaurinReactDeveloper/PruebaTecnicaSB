using GestorEmpleados.Application.Dtos.EmployeeDto;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace GestorEmpleados.Application.Validations
{
    public static class EmployeeValidations
    {
        public static List<string> EmployeeValidation(EmployeeDto employee)
        {
            List<string> errors = new List<string>();

            if (employee == null)
            {
                errors.Add("Los datos del empleado no pueden ser nulos.");
                return errors;
            }

            // 1. Validaciones generales comunes
            ValidateCommonFields(employee, errors);

            // 2. Validaciones específicas según el tipo de empleado
            switch (employee.EmployeeTypeId)
            {
                case 1: // Empleado Asalariado
                    ValidateSalariedEmployee(employee, errors);
                    break;

                case 2: // Empleado por Horas
                    ValidateHourlyEmployee(employee, errors);
                    break;

                case 3: // Empleado por Comisión
                    ValidateCommissionEmployee(employee, errors);
                    break;

                case 4: // Empleado Asalariado por Comisión
                    ValidateBasePlusCommissionEmployee(employee, errors);
                    break;

                default:
                    errors.Add("El tipo de empleado especificado no es válido.");
                    break;
            }

            return errors;
        }

        public static bool IsInvalidEmployeeList(List<EmployeeModel> employees)
        {
            return employees == null || !employees.Any();
        }

        public static bool IsNullEmployee(EmployeeModel employee)
        {
            return employee == null;
        }

        public static bool IsInvalidEmployeeId(EmployeeDto employee)
        {
            return employee == null || employee.EmployeeId == 0;
        }

        #region Private Validation Methods

        private static void ValidateCommonFields(EmployeeDto employee, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(employee.LastName))
                errors.Add("El apellido paterno es obligatorio.");

            if (string.IsNullOrWhiteSpace(employee.SocialSecurityNumber))
                errors.Add("El número de seguro social es obligatorio.");
        }

        private static void ValidateSalariedEmployee(EmployeeDto employee, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                errors.Add("El primer nombre es obligatorio para un empleado asalariado.");

            if (!employee.WeeklySalary.HasValue || employee.WeeklySalary <= 0)
                errors.Add("El salario semanal es obligatorio y debe ser mayor a cero.");
        }

        private static void ValidateHourlyEmployee(EmployeeDto employee, List<string> errors)
        {
            if (!employee.HourlyRate.HasValue || employee.HourlyRate <= 0)
                errors.Add("El sueldo por hora es obligatorio y debe ser mayor a cero.");

            if (!employee.HoursWorked.HasValue || employee.HoursWorked < 0)
                errors.Add("Las horas trabajadas son obligatorias y no pueden ser negativas.");
        }

        private static void ValidateCommissionEmployee(EmployeeDto employee, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(employee.FirstName))
                errors.Add("El primer nombre es obligatorio para un empleado por comisión.");

            if (!employee.GrossSales.HasValue || employee.GrossSales < 0)
                errors.Add("Las ventas brutas son obligatorias y no pueden ser negativas.");

            if (!employee.CommissionRate.HasValue || employee.CommissionRate <= 0 || employee.CommissionRate > 1)
                errors.Add("La tarifa de comisión es obligatoria y debe ser un porcentaje válido entre 0 y 1 (ej: 0.10 para 10%).");
        }

        private static void ValidateBasePlusCommissionEmployee(EmployeeDto employee, List<string> errors)
        {
            ValidateCommissionEmployee(employee, errors);

            if (!employee.BaseSalary.HasValue || employee.BaseSalary <= 0)
                errors.Add("El salario base es obligatorio y debe ser mayor a cero.");
        }

        #endregion
    }
}