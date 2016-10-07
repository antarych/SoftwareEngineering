using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public interface IPeriodOfTime
    {
        OperationsWithCollections FindFilmsForAPeriodOfTime(string nickname, string generalListSerialized, DateTime start, DateTime end);
    }
}
