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
            var createIdStub = new RegistrationServiceStub();

            var actualId = createIdStub.CreateNewId();

            Assert.IsTrue(createIdStub.calledCreateId);

        }

        [TestMethod]
        public void AddUser_ReturnsFirstId()
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
            LearnedWord[] expectedLearnedWords = new LearnedWord[1];
            expectedLearnedWords[0]  = new LearnedWord("word", "translation");

            profile.AddLearnedWord(word);

            CollectionAssert.AreEqual(expectedLearnedWords, profile.LearnedWords);
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
        //    string pathToFileWithWords = "EnglishTraining.Properties.Resources.words";
        //    UserProfileRepository userProfileRepository = new UserProfileRepository("EnglishTraining.Properties.Resources.profiles");
        //    var getAllWords = new VocabularyService(pathToFileWithWords, userProfileRepository);
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
    }
}

public class RegistrationServiceStub:IRegistrationService
{
    public bool calledAdd = false;
    UserProfileRepository userProfileRepository = new UserProfileRepository("EnglishTraining.Properties.Resources.profiles");
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
        int id = 1;
        return id;
    }
}



