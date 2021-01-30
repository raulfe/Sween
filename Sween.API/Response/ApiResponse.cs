using Sween.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sween.API.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public ApiResponse(T data)
        {
            Data = data;
        }

        public Metadata Meta { get; set; }
    }
}
