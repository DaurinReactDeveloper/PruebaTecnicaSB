using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Domain.Core
{
    public abstract class BaseEntity
    {

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool Deleted { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }


    }
}
