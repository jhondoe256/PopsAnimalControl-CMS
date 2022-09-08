using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.Contracts.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> Get(string URL);
        Task<T> Get(string URL,int id);
        Task<bool> Delete(string URL, int id);
        Task<bool> Create(string URL, T entity);
        Task<bool> Update(string URL, int id, T entity);
        // Task<bool> Save();
    }
}