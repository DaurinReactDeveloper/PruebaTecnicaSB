using GestorEmpleados.Domain.Entities;
using GestorEmpleados.Domain.Repository;
using GestorEmpleados.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Persistence.Interfaces
{
    public interface IUser : IBaseRepository<User>
    {
        Task<UserModel> GetUserByEmail(string email);
        Task<List<Vw_UserDetailModel>> GetUsers();
        Task<UserModel> GetUserById(int Id);

    }
}
