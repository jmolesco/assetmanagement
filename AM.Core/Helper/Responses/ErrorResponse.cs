using System.Collections.Generic;

namespace AM.Core.Helper.Responses
{
    public class ErrorResponse : BaseResponse
    {

        public ErrorResponse()
        {
            this.ErrorMessages = new List<object>();
        }

        public List<object> ErrorMessages { get; set; }

    }
}
