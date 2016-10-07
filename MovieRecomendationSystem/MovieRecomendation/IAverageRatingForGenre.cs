using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public interface IAverageRatingForGenre
    {
        OperationsWithCollections FindAverageRatingForGenre(string nickname, string generalListSerialized);
    }
}
