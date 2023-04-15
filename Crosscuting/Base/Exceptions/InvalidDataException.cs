namespace Crosscuting.Base.Exceptions
{
    public class InvalidDataException : Exception
    {
        /// <summary>
        /// Exception with informational message.
        /// </summary>
        /// <param name="message"></param>
        public InvalidDataException(string message) : base(message) { }

        /// <summary>
        /// Exception with an informational message and the inner exception raised.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidDataException(string message, Exception innerException) : base(message, innerException) { }
    }
}
