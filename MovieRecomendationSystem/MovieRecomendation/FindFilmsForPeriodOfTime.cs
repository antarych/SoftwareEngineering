using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public class FindFilmsForPeriodOfTime
    {
        public FindFilmsForPeriodOfTime(IPeriodOfTime periodOfTime)
        {
            _periodOfTime = periodOfTime;
        }

        public OperationsWithCollections FindFilmsForAPeriodOfTime(string nickname, string generalListSerialized, DateTime start, DateTime end)
        {
            var filmsForPeriodOfTime = _periodOfTime.FindFilmsForAPeriodOfTime(nickname, generalListSerialized, start, end);
            return filmsForPeriodOfTime;
        }

        private readonly IPeriodOfTime _periodOfTime;
    }
}
