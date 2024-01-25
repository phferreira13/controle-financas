using AccountService.Shared.Enums;
using AccountService.Shared.Services;

namespace AccountService.Shared.Models
{
    public class ApiResult<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = [];
        private bool _isValid = true;

        public void AddError(string error)
        {
            Success = false;
            Errors.Add(error);
        }

        public ApiResult<T> SetData(T data)
        {
            Success = true;
            Data = data;
            return this;
        }

        public ApiResult<T> Validate(bool validation)
        {
            _isValid = validation;
            return this;
        }

        public void HandleError(Exception ex, string? customErrorMessage = null)
        {
            if (customErrorMessage != null)
                AddError($"{ex.Message} - {customErrorMessage}");
            else
                AddError(ex.Message);
        }

        public void HandleError(EErrorType errorType, string? customErrorMessage = null)
        {
            var exeption = ErrorMessageService.GetException(errorType, customErrorMessage);
            AddError(exeption.Message);
        }

        public ApiResult<T> OnValidateFail(EErrorType errorType, string? customErrorMessage = null)
        {
            if (!_isValid)
                HandleError(errorType, customErrorMessage);
            return this;
        }

        public async Task<ApiResult<T>> ExecuteAsync(Func<Task<T>> func, string? customErrorMessage = null, bool errorOnNull = true)
        {
            try
            {
                var data = await func();
                if (data == null && errorOnNull)
                    HandleError(EErrorType.NotFound, customErrorMessage);
                else
                    SetData(data);
            }
            catch (Exception ex)
            {
                HandleError(ex, customErrorMessage);
            }

            return this;
        }

    }
}
