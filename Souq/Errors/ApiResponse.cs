using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souq.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource is found, it is not",
                500 => "Errors are the path to dark side. Errors Lead to Anger. Anger Lead to hate. Hate lead to career shift",
                _ => "Default Error"
            };
        }
    }
}
