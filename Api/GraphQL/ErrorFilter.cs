namespace Api.GraphQL
{
    /// <summary>
    /// Error filter to serialized Exceptions into error with meaningful message.
    /// </summary>
    public class ErrorFilter : IErrorFilter
    {
        ///<inheritdoc />
        public IError OnError(IError error)
        {
            return error.WithMessage(error.Exception.Message);
        }
    }
}
