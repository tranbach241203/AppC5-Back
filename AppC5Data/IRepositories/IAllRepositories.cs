using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface IAllRepositories<T> 
    {
        IEnumerable<T> GetAll();
        bool CreateItem(T item);
        bool DeleteItem(T item);
        bool UpdateItem(T item);
    }
}
