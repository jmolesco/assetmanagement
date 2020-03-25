using System.Collections.Generic;

namespace AM.Core.Helper.Responses
{
    public class GetAllResponse : BaseResponse
    {

        public GetAllResponse(int total)
        {
            this.Total = total;
            this.List = new List<object>();
            this.CurrentPage = 1;
            this.TotalPage = 1;
            base.Success = true;
        }

        public GetAllResponse(int total, int currentPage, int recordDisplayPerPage)
        {
            this.Total = total;
            this.CurrentPage = currentPage;
            this.TotalPage = (total / recordDisplayPerPage) + 1;
            this.List = new List<object>();
            base.Success = true;
        }

        public int Total { get; }

        public int CurrentPage { get; }

        public int TotalPage { get; }

        public List<object> List { get; set; }

    }
}
