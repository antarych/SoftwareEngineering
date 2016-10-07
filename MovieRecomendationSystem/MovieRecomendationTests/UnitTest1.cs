using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRecomendation;

namespace MovieRecomendationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FinderSameFilmsTest()
        {
            var sameFilmsFinderStub = new SameFilmsFinderStub();
            var findSameFilms = new FindSameMovies(sameFilmsFinderStub);

            var listOfSameFilms = findSameFilms.FindUsersWithSameMovies("name", "List");

            Assert.IsTrue(sameFilmsFinderStub.called);
        }

        [TestMethod]
        public void FinderAverageRatingForCollectionTest()
        {
            var averageValuseCounterStub = new AverageRatingCounterForCollectionStub();
            var findRating = new AverageRatingForCollection(averageValuseCounterStub);

            var rating = findRating.FindAverageRatingForUserCollection("name", "List");

            Assert.IsTrue(averageValuseCounterStub.called);
        }

        [TestMethod]
        public void FinderAverageRatingForGenreTest()
        {
            var averageValuseCounterStub = new AverageRatingCounterForGenreStub();
            var findRating = new AverageRatingForGenre(averageValuseCounterStub);

            var rating = findRating.FindAverageRatingForGenre("name", "List");

            Assert.IsTrue(averageValuseCounterStub.called);
        }

        [TestMethod]
        public void FinderFilmsForPeriodOfTimeTest()
        {
            var filmsForPeriodOfTime = new FilmsForPeriodOfTimeStub();
            var listOfFilms = new FindFilmsForPeriodOfTime(filmsForPeriodOfTime);

            var rating = listOfFilms.FindFilmsForAPeriodOfTime("name", "List", new DateTime(2016, 02, 11), DateTime.Today);

            Assert.IsTrue(filmsForPeriodOfTime.called);
        }

        [TestMethod]
        public void UserRegistrationTest()
        {
            var nickname = "nickname";
            var name = "name";
            var surname = "surname";
            var mail = "mail";
            var expectedValue = "{\"Nickname\":\"nickname\",\"Name\":\"name\",\"Surname\":\"surname\",\"Mail\":\"mail\"}";
            var userRegistration = new UserRegistration();

            var actualValue = userRegistration.AddUser(nickname, name, surname, mail);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void FilmAdditionTest()
        {
            var nickname = "nickname";
            var title = "title";
            var director = "director";
            Genres genre = 0;
            var rating = 8.0;
            var date = DateTime.Today.ToString("d");
            var movieAddition = new MovieAddition();
            string[] expectedValue = { "nickname", "{\"Title\":\"title\",\"Director\":\"director\",\"Genre\":0,\"Rating\":8.0}", date };

            var actualValue = movieAddition.OneMovieAddition(nickname, title, director, genre, rating);

            CollectionAssert.AreEqual(expectedValue, actualValue);

        }
    }
}

public class SameFilmsFinderStub:IFindSameMovies
{
    public bool called = false;
    public OperationsWithCollections FindUsersWithSameMovies(string nickname, string generalListSerialized)
    {
        called = true;
        return new OperationsWithCollections();
    }
}

public class AverageRatingCounterForCollectionStub : IAverageRatingForCollection
{
    public bool called = false;
    public OperationsWithCollections FindAverageRatingForUsersMovies(string nickname, string generalListSerialized)
    {
        called = true;
        return new OperationsWithCollections();
    }
}

public class AverageRatingCounterForGenreStub : IAverageRatingForGenre
{
    public bool called = false;
    public OperationsWithCollections FindAverageRatingForGenre(string nickname, string generalListSerialized)
    {
        called = true;
        return new OperationsWithCollections();
    }
}

public class FilmsForPeriodOfTimeStub : IPeriodOfTime
{
    public bool called = false;
    public OperationsWithCollections FindFilmsForAPeriodOfTime(string nickname, string generalListSerialized, DateTime start, DateTime end)
    {
        called = true;
        return new OperationsWithCollections();
    }
}