using GestorEmpleados.Application.Dtos.UserDto;
using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GestorEmpleados.Application.Validations
{
    public static class UserValidations
    {
        public static List<string> ValidateUser(UserDto user)
        {
            List<string> errors = new List<string>();

            if (user is null)
            {
                errors.Add("Los datos del usuario no pueden ser nulos.");
                return errors;
            }

            // Ejecutar las reglas de negocio para el usuario
            ValidateRequiredFields(user, errors);
            ValidateEmailFormat(user.Email, errors);
            ValidatePasswordStrength(user.PasswordHash, errors);

            return errors;
        }

        public static bool UserExists(UserModel user)
        {
            return user != null;
        }

        public static bool IsInvalidEmail(string email)
        {
            return string.IsNullOrWhiteSpace(email);
        }

        public static bool IsInvalidUserList(List<UserModel> users)
        {
            return users == null || !users.Any();
        }

        public static bool IsNullUser(UserModel user)
        {
            return user == null;
        }

        public static bool IsInvalidEmployeeId(UserDto user)
        {
            return user == null || user.UserId == 0;
        }

        #region Private Validation Methods

        private static void ValidateRequiredFields(UserDto user, List<string> errors)
        {
            if (user.EmployeeId <= 0)
                errors.Add("El usuario debe estar asociado a un empleado válido.");

            if (string.IsNullOrWhiteSpace(user.Username))
                errors.Add("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(user.Email))
                errors.Add("El correo electrónico es obligatorio.");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                errors.Add("La contraseña es obligatoria.");

            if (user.RoleId <= 0)
                errors.Add("Debe asignar un rol válido al usuario.");
        }

        private static void ValidateEmailFormat(string email, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(email)) return;

            // Expresión regular estándar para validar correos electrónicos
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!emailRegex.IsMatch(email))
            {
                errors.Add("El formato del correo electrónico no es válido.");
            }
        }

        private static void ValidatePasswordStrength(string password, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(password)) return;

            if (password.Length < 8)
            {
                errors.Add("La contraseña debe tener al menos 8 caracteres.");
            }
        }

        #endregion
    }
}