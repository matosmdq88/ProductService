namespace ProductsService.Pipelines.Exceptions
{
    ///<summary>
    ///Description: Excepcion que sera utilizada para errores provenientes de la logica de negocio.
    ///Throw: Handlers.
    ///</summary>
    public class BussinessLogicalException : Exception
    {
        public BussinessLogicalException(string message) : base(message)
        {
            this.SetSeverityLevel(LogLevel.Error);
        }
    }
}
