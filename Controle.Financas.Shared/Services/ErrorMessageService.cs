using AccountService.Shared.Enums;

namespace AccountService.Shared.Services
{
    public static class ErrorMessageService
    {
        public static Exception GetException(EErrorType errorType, string? message = null)
        {
            return new Exception(GetErrorMessage(errorType, message));
        }
        public static string GetErrorMessage(EErrorType errorType, string? message = null)
        {
            var errorMessage = GetDefaultErrorMessage(errorType);
            if (message != null)
            {
                errorMessage += $" - {message}";
            }
            return errorMessage;
        }

        private static string GetDefaultErrorMessage(EErrorType errorType)
        {
            return errorType switch
            {
                EErrorType.NotFound => "Not found",
                EErrorType.BadRequest => "Invalid request",
                EErrorType.InternalServerError => "Internal error",
                _ => "Internal error"
            };
        }
    }
}
