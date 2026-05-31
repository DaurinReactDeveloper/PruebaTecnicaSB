using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Application.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.ResultType = MessageType.Success;
        }

        public MessageType ResultType { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

    }
}
