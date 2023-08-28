using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealsPlace.Storage.Interfaces
{
    public interface IBaseStorage<T>
    {
        public Task CreateAsync(T item);
        public Task<T> UpdateAsync(T item);
        public Task DeleteAsync(T item);
        public Task<T> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
