namespace BlazorApp.Services.Contracts
{
    /// <summary>
    /// Get resources by item selected
    /// </summary>
    public interface IFilterService<T>
    {
        /// <summary>
        /// Get elements of collection by category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetByCategory(int id);
        /// <summary>
        /// Get elements of collection by price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetByPrice(decimal price);
        /// <summary>
        /// Get elements of collection by range price
        /// </summary>
        /// <param name="minprice"></param>
        /// <param name="maxprice"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetByRangePrice(decimal minprice, decimal maxprice);
        /// <summary>
        /// Get elements of collections by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetByTitle(string title);
    }
}
