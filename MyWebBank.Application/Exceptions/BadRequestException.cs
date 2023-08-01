using FluentValidation.Results;

namespace MyWebBank.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]>? ValidationErrors { get; set; }
        public BadRequestException() : base() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }
    }
}
