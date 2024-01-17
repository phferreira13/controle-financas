using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Financas.Shared.Models
{
    public class ApiResult<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public List<string> Errors { get; private set; } = [];

        public void AddError(string error)
        {
            Success = false;
            Errors.Add(error);
        }

        public void SetData(T data)
        {
            Success = true;
            Data = data;
        }
    }
}
