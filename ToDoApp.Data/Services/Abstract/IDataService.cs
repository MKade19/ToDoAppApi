namespace ToDoApp.Data.Services.Abstract
{
    public interface IDataService <T>
    {
        Task CreateOneAsync(T entity);

        Task DeleteByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task UpdateByIdAsync(T entity);
    }
}
