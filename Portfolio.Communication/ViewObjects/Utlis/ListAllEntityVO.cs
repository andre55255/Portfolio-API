namespace Portfolio.Communication.ViewObjects.Utlis
{
    public class ListAllEntityVO<T> where T : class
    {
        public List<T> Items { get; set; } = new List<T>();
        public int? TotalItems { get; set; } = null;
        public int? TotalPages { get; set; } = null;
        public bool? HasNextPage { get; set; } = null;
        public bool? HasPreviousPage { get; set; } = null;
    }
}
