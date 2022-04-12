using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProyectoBCP_API.Dto;
using ProyectoBCP_API.Exceptions;

namespace Remi.Api.Filters
{
    public class CustomExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            
            switch (exception)
            {
                case UnauthorizedException _:
                    context.Result = new ObjectResult(new WrapperResponse<object>(message: exception.Message))
                    {
                        StatusCode = 401
                    };
                    break;
                case ForbiddenException _:
                    context.Result = new ObjectResult(new WrapperResponse<object>(message: exception.Message))
                    {
                        StatusCode = 403
                    };
                    break;
                case BadRequestException _:
                    context.Result = new ObjectResult(new WrapperResponse<object>(message: exception.Message))
                    {
                        StatusCode = 400
                    };
                    break;
                case NotFoundException _:
                    ;
                    context.Result = new ObjectResult(new WrapperResponse<object>(message: exception.Message))
                    {
                        StatusCode = 404
                    };
                    break;
                case InternalErrorException _:
                    context.Result = new ObjectResult(new WrapperResponse<object>(message: exception.Message))
                    {
                        StatusCode = 500
                    };
                    break;
                default:
                    context.Result = new ObjectResult(new WrapperResponse<object>(message: exception.Message))
                    {
                        StatusCode = 500
                    };
                    break;
            }
            context.ExceptionHandled = true;
        }
    }
}