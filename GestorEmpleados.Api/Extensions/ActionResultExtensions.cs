using GestorEmpleados.Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace GestorEmpleados.Api.Extensions
{
    public static class ActionResultExtensions
    {

        public static IActionResult ToActionResult(this ControllerBase controller, ServiceResult result)
        {
            switch (result.ResultType)
            {
                case MessageType.Success:
                    return controller.Ok(result); // HTTP 200

                case MessageType.NotFound:
                    return controller.NotFound(result); // HTTP 404

                case MessageType.Warning:
                    return controller.BadRequest(result); // HTTP 400

                case MessageType.Unauthorized:
                    return controller.Unauthorized(result); // HTTP 401

                case MessageType.Error:
                    return controller.StatusCode(StatusCodes.Status500InternalServerError, result); // HTTP 500

                default:
                    return controller.BadRequest(result); // HTTP 400 
            }
        }

    }
}
