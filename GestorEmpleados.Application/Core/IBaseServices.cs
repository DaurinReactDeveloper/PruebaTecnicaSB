using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Core
{
    public interface IBaseServices<AddDto, UpdateDto, RemoveDto>
    {
        Task<ServiceResult> Add(AddDto modelDto);
        Task<ServiceResult> Remove(RemoveDto modelDto);
        Task<ServiceResult> Update(UpdateDto modelDto);

    }
}
