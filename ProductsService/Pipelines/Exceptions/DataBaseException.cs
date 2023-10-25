namespace ProductsService.Pipelines.Exceptions
{
    ///<summary>
    ///Description: Excepcion que sera utilizada para errores provenientes de la base de datos.
    ///Throw: Repository.
    ///</summary>
    public class DataBaseException : Exception
    {
        public DataBaseException(Exception ex) : base("Ha ocurrido un error en la conexión con la base de datos", ex)
        {
            this.SetSeverityLevel(LogLevel.Critical);
        }
    }
}
