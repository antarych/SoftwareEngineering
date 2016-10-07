using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public class FindSameMovies
    {
        public FindSameMovies(IFindSameMovies findSameMovies)
        {
            _findSameMovies = findSameMovies;
        }

        public OperationsWithCollections FindUsersWithSameMovies(string nickname, string generalListSerialized)
        {
            var similarUsers = _findSameMovies.FindUsersWithSameMovies(nickname, generalListSerialized);
            return similarUsers;
        }


        private readonly IFindSameMovies _findSameMovies;
    }
}
