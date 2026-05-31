using GestorEmpleados.Application.Core;
using GestorEmpleados.Application.Dtos.UserDto;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Contract
{
    public interface IUserServices : IBaseServices<UserAddDto,UserUpdateDto,UserRemoveDto>
    {
        Task<ServiceResult> GetUsers();
        Task<ServiceResult> GetUserByEmail(string email);
        Task<ServiceResult> Login(string email, string password);
    }
}
