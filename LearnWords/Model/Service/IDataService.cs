using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWords.Model.Service
{
    internal interface IDataService<T>
    {
        Task<bool> Create(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetTen(bool enua);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);
    }
}
