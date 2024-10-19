namespace LT.Core.Common
{
    /// <summary>
    /// Class can be used as a wrapper class for Server side Pagination list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginedList<T>
    {
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }
}
