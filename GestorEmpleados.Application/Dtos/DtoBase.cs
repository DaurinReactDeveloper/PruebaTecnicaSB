using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Dtos
{
    public abstract class DtoBase
    {
        public DateTime ChangeDate { get; set; }

        public string ChangeUser { get; set; }

    }
}
