using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public class AverageRatingForCollection
    {
        public AverageRatingForCollection(IAverageRatingForCollection averageValues)
        {
            _averageValues = averageValues;
        }

        public OperationsWithCollections FindAverageRatingForUserCollection(string nickname, string generalListSerialized)
        {
            var averageRatingForCollection = _averageValues.FindAverageRatingForUsersMovies(nickname, generalListSerialized);
            return averageRatingForCollection;          
        }

        private readonly IAverageRatingForCollection _averageValues;
    }
}
