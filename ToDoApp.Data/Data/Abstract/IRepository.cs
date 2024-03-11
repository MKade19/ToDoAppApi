﻿namespace ToDoApp.Data.Data.Abstract
{
    public interface IRepository<T>
    {
        Task CreateOneAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateByIdAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
