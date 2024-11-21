using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<T> GetAsync();
}
