namespace BlazorApp.Services.Contracts
{
    /// <summary>
    /// Admin resources of class
    /// </summary>
    /// <typeparam name="T">Entity Class</typeparam>
    public interface IRepository<T>
    {
        string Message { get; set; }
        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Add(T entity);
        /// <summary>
        /// Delete a entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);
        /// <summary>
        /// Get all Entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> Get();
        /// <summary>
        /// Get a entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Update a entity by Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Update(T entity);
    }
}