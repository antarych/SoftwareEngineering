using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnglishTraining;
using System.IO;
using System.Collections.Generic;

namespace EnglishTrainingTests
{
    [TestClass]
    public class EnglishTrainingUnitTests
    {
        [TestMethod]
        public void CreateNewId()
        {
        //    //var createIdStub = new RegistrationServiceStub();

        //    //var actualId = createIdStub.CreateNewId();

        //    //Assert.IsTrue(createIdStub.calledCreateId);

            var createIdStub = new RegistrationServiceStub();
            var expectedId = 1;
            var actualId = createIdStub.CreateNewId();

            Assert.AreEqual(expectedId, actualId);

        }

        [TestMethod]
        public void AddUser_ReturnsId()
        {
            var nickname = "nickname";
            var addUserStub = new RegistrationServiceStub();

            var actualId = addUserStub.AddUser(nickname);

            Assert.IsTrue(addUserStub.calledAdd);
        }

        [TestMethod]
        public void AddLearnedWordTest()
        {
            LearnedWord[] learnedWords = new LearnedWord[0];
            LearnedWord word = new LearnedWord("word", "translation");
            var profile = new UserProfile(1, "nickname", learnedWords, null);
            var expectedLearnedWord  = new LearnedWord("word", "translation");            

            profile.AddLearnedWord(word);
            LearnedWord actualLearnedWord = new LearnedWord(profile.LearnedWords[0].Word, profile.LearnedWords[0].Translation);

            Assert.IsTrue(expectedLearnedWord == actualLearnedWord);
        }

        [TestMethod]
        public void GetOnlyEnglishWord()
        {
            var wordWithTranslation = "word translation";
            var expextedWord = "word";
            string pathToFileWithWords = "path";
            UserProfileRepository userProfileRepository = new UserProfileRepository("path");
            var getOnlyEnglishWord = new VocabularyService(pathToFileWithWords, userProfileRepository);

            var actualWord = getOnlyEnglishWord.GetOnlyEnglishWord(wordWithTranslation);

            Assert.AreEqual(expextedWord, actualWord);
        }

        //[TestMethod]
        //public void GetAllWordsTest()
        //{
        //    string pathToFileWithWords = "EnglishTrainingTests.Properties.Resources.words";
        //    UserProfileRepository userProfileRepository = new UserProfileRepository("EnglishTrainingTests.Properties.Resources.profiles");
        //    var getAllWords = new VocabularyService(EnglishTrainingTests.Properties.Resources, userProfileRepository);
        //    string[] expectedMassive = new string[] { "word1 translation1", "word2 translation2", "word3 translation3", "word4 translation4", "word5 translation5" };

        //    var actualMassive = File.ReadAllLines(pathToFileWithWords);

        //    CollectionAssert.AreEqual(expectedMassive, actualMassive);
        //}

        [TestMethod]
        public void CheckAnswerTest_True()
        {
            string pathToFileWithWords = "path";
            UserProfileRepository userProfileRepository = new UserProfileRepository("path");
            var checkAnswer = new VocabularyService(pathToFileWithWords, userProfileRepository);
            var word = "word1 translation1";
            string[] variantsOfTranslation = new string[] { "transtation", "fghj", "translation1", "fghjk" };
            int answer = 3;

            var actualAnswer = checkAnswer.CheckAnswer(answer, word, variantsOfTranslation);

            Assert.IsTrue(actualAnswer);
        }

        [TestMethod]
        public void CheckAnswerTest_False()
        {
            string pathToFileWithWords = "path";
            UserProfileRepository userProfileRepository = new UserProfileRepository("path");
            var checkAnswer = new VocabularyService(pathToFileWithWords, userProfileRepository);
            var word = "word1 translation1";
            string[] variantsOfTranslation = new string[] { "transtation", "fghj", "translation1", "fghjk" };
            int answer = 2;

            var actualAnswer = checkAnswer.CheckAnswer(answer, word, variantsOfTranslation);

            Assert.IsFalse(actualAnswer);
        }

        [TestMethod]
        public void SaveProfileTest()
        {
            var userProfileRepositoryStub = new UserProfileRepositoryStub();
            
            UserProfile profile = new UserProfile(1, "name", new LearnedWord[0], new WordInProgress[0]);

            userProfileRepositoryStub.SaveProfile(profile);

            Assert.IsTrue(userProfileRepositoryStub.calledSaving);
        }

        [TestMethod]
        public void GetAllProfilesTest()
        {
            var userProfileRepositoryStub = new UserProfileRepositoryStub();

            userProfileRepositoryStub.GetAllProfiles();

            Assert.IsTrue(userProfileRepositoryStub.calledGetAll);
        }

        [TestMethod]
        public void GetOneProfileTest()
        {
            var userProfileRepositoryStub = new UserProfileRepositoryStub();
            var userId = 1234;

            userProfileRepositoryStub.GetOneProfile(userId);

            Assert.IsTrue(userProfileRepositoryStub.calledGetOneProfile);
        }
    }
}

public class RegistrationServiceStub:IRegistrationService
{
    public bool calledAdd = false;
    UserProfileRepository userProfileRepository = new UserProfileRepository("path");
    public int AddUser(string nickname)
    {
        calledAdd = true;
        int id = 1;
        return id;
    }
    public bool calledCreateId = false;
    public int CreateNewId()
    {
        calledCreateId = true;
        UserProfile[] allProfiles = new UserProfile[0];
        return allProfiles.Length + 1;
    }
}

public class UserProfileRepositoryStub : IRepository<UserProfile>
{
    public bool calledGetAll = false;
    public UserProfile[] GetAllProfiles()
    {
        calledGetAll = true;
        return new UserProfile[] { new UserProfile(1, "name", new LearnedWord[0], new WordInProgress[0]) };
    }


    public bool calledSaving = false;

    public void SaveProfile(UserProfile profile)
    {
        UserProfileRepository saveProfile = new UserProfileRepository("path");
        calledSaving = true;
    }

    public bool calledGetOneProfile = false;
    public UserProfile GetOneProfile(int UserId)
    {
        calledGetOneProfile = true;
        return new UserProfile(1, "name", new LearnedWord[0], new WordInProgress[0]);
    }
}



