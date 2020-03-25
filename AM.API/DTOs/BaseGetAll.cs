namespace AM.API.DTOs
{
    public abstract class BaseGetAll
    {

        public BaseGetAll()
        {
            CurrentPage = 1;
        }

        /// <summary>
        /// Holds current page position.
        /// Default is 1.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// True to display all records, otherwise false.
        /// </summary>
        public bool ShowAll { get; set; }

    }
}
