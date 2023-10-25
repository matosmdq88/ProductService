using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Base;
using System.Net;
using ProductsService.Pipelines.Exceptions;

namespace ProductsService.Pipelines
{
    public class ExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        private Dictionary<Type, int> MapExceptions = new Dictionary<Type, int>()
        {
            {typeof(DataBaseException), (int)HttpStatusCode.InternalServerError },
            {typeof(BussinessLogicalException), (int)HttpStatusCode.BadRequest },
            {typeof(NotFoundException), (int)HttpStatusCode.NotFound },
        };

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var response = new BaseResponse(false);
            Exception exception = context.Exception;

            int statusCode;
            string message = context.Exception.Message;

            if (!MapExceptions.TryGetValue(context.Exception.GetType(), out statusCode))
            {
                message = "Ha ocurrido un error genérico";
                statusCode = (int)HttpStatusCode.InternalServerError;
            }
            if (exception.GetSeverityLevel() == LogLevel.Critical)
            {
                if (exception.HasOriginName())
                {
                    _logger.Log(exception.GetSeverityLevel(), exception, $"[{exception.GetOriginName()}] {exception.GetType().Name}: {exception.Message} " +
                                   $"\n => La excepcion se produjo en el handler: {exception.GetFullNameHandler()}");
                }
                else
                {
                    _logger.Log(exception.GetSeverityLevel(), exception, $"{exception.GetType().Name}: {exception.Message} " +
                                 $"\n => La excepcion se produjo en el handler: {exception.GetFullNameHandler()}");
                }
            }

            response.Message = message;
            response.ResultCode = statusCode;

            var jsonResult = new ObjectResult(response);
            jsonResult.StatusCode = statusCode;

            context.Result = jsonResult;
            context.ExceptionHandled = true;
        }
    }
}
