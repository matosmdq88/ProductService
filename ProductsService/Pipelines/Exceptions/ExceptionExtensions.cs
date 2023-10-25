namespace ProductsService.Pipelines.Exceptions
{
    /// <summary>
    /// Metodos de extension para Excepciones.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Permite obtener el nivel de severidad de una exception.
        /// El valor por defecto es Critical.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static LogLevel GetSeverityLevel(this Exception ex)
        {
            var severityLevel = ex.Data["SeverityLevel"];
            return severityLevel != null ? (LogLevel)severityLevel : LogLevel.Critical;
        }

        /// <summary>
        /// Permite indicar el nivel de severidad de una exception.
        /// El valor por defecto es Critical.
        /// Devuelve la misma excepcion para permitir indicar el nivel de severidad en una misma linea.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="logLevel"></param>
        public static Exception SetSeverityLevel(this Exception ex, LogLevel logLevel)
        {
            ex.Data["SeverityLevel"] = logLevel;
            return ex;
        }

        /// <summary>
        /// Permite conocer si existe el nombre del objeto que originó esta excepcion.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool HasOriginName(this Exception ex)
        {
            var originname = ex.Data["OriginName"];
            return originname != null;
        }

        /// <summary>
        /// Permite obtener el nombre del objeto que originó esta excepcion.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetOriginName(this Exception ex)
        {
            var originname = ex.Data["OriginName"];
            return originname != null ? originname.ToString() : "UnknownObject";
        }

        /// <summary>
        /// Permite indicar el nombre del objeto que originó esta excepcion.
        /// Devuelve la misma excepcion para permitir concatenar acciones.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="Origin"></param>
        public static Exception SetOriginName<T>(this Exception ex, T Origin)
        {
            ex.Data["OriginName"] = typeof(T).Name;
            return ex;
        }

        /// <summary>
        /// Permite indicar el nombre del handler que procesaba el request al momento de instanciarse la excepción.
        /// Devuelve la misma excepcion para permitir concatenar acciones.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="Handler"></param>
        public static Exception SetHandler<T>(this Exception ex, T Handler)
        {
            ex.Data["FullHandlerName"] = typeof(T).FullName;
            return ex;
        }

        /// <summary>
        /// Permite obtener el nombre completo del objeto que originó esta excepcion.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetFullNameHandler(this Exception ex)
        {
            var handlerName = ex.Data["FullHandlerName"];
            return handlerName != null ? handlerName.ToString() : "UnknownObject";
        }
    }
}
