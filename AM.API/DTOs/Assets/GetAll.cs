using AM.Core.Domain.Assets;

namespace AM.API.DTOs.Assets
{
    public class GetAll : BaseGetAll
    {

        /// <summary>
        /// Define order by column
        /// </summary>
        public OrderBy? OrderBy { get; set; }

        /// <summary>
        /// Define order type (ASC or DESC)
        /// </summary>
        public OrderType? OrderType { get; set; }

        /// <summary>
        /// Search records by keyword. 
        /// Keyword should be at least 3 characters
        /// </summary>
        public string Keyword { get; set; }

    }
}
