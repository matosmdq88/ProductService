namespace ProductsService.Pipelines.Exceptions
{
    ///<summary>
    ///Description: Excepcion que sera utilizada cuando no se encuentra un registro que debería existir.
    ///Throw: Handler.
    ///</summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            this.SetSeverityLevel(LogLevel.Error);
        }
    }
}
