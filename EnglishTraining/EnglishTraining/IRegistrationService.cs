using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public interface IRegistrationService
    {
        int AddUser(string nickname);

        int CreateNewId();
    }
}
