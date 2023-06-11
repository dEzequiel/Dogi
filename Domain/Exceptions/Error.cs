using Domain.Common;

namespace Domain.Exceptions
{
    /// <summary>
    /// Rpresents a concrete domain error.
    /// </summary>
    public sealed class Error : ValueObject
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Message;
        }

        /// <summary>
        /// Gets the empty error instance.
        /// </summary>
        internal static Error None => new Error(string.Empty, string.Empty);
    }
}
