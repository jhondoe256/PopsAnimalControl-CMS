using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.Contracts.IBase_Repository
{
    public interface IBaseRepository<T> where T:class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<bool> Post(T entitiy);
        Task<bool> Put(T entity);
        Task<bool> Delete(int id);
        Task<bool> Save();
    }
}
