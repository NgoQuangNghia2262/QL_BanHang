using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal interface ICollection<T>
    {
        T Find(string key);
        void Save();
        T[] Find();
    }
}
