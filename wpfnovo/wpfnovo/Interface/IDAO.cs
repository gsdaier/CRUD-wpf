using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfnovo.Interface
{
    /// <summary>
    /// Interface (contrato) para classes DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDAO<T>
    {
        bool Insert(T t);

        void Update(T t);

        bool Delete(T t);

        List<T> List();
    }
}
