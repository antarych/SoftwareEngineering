using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public interface IRepository<T>
    {
        T[] GetAllProfiles();

        void SaveProfile(T entity);
    }
}
