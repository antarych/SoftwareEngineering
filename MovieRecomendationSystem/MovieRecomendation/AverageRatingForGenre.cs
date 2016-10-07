using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public class AverageRatingForGenre
    {
        public AverageRatingForGenre(IAverageRatingForGenre averageValues)
        {
            _averageValues = averageValues;
        }

        public OperationsWithCollections FindAverageRatingForGenre(string nickname, string generalListSerialized)
        {
            var averageRatingForGenre = _averageValues.FindAverageRatingForGenre(nickname, generalListSerialized);
            return averageRatingForGenre;
        }

        private readonly IAverageRatingForGenre _averageValues;
    }
}
