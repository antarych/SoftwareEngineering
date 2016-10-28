using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnglishTraining
{
    public class VocabularyService: IVocabularyService
    {
        public VocabularyService(string pathToFileWithWords, UserProfileRepository userProfileRepository)
        {
            _pathToFileWithWords = pathToFileWithWords;
            _userProfileRepository = userProfileRepository;
        }

        public string[] GetAllWords()
        {
            string[] allWords = null;
            if (File.Exists(_pathToFileWithWords) == true)
            {
                allWords = File.ReadAllLines(_pathToFileWithWords);
            }
            return allWords; ;
        }

        public string[] GetWordsForExercise(int userId)
        {
            string[] wordsForExercise = new string[numberOfWordsInExercise];
            if (File.Exists(_pathToFileWithWords) == true)
            {
                string[] allWordsWithTranslation = File.ReadAllLines(_pathToFileWithWords);
                for (int i = 0; i < wordsForExercise.Length; i++)
                {
                    
                }
            }
            return wordsForExercise;
        }
        public string GetEnglishWordWithTranslation(int userId)
        {
            UserProfile userProfile = _userProfileRepository.GetOneProfile(userId);
            string[] allWordsWithTranslation = GetWordsForExercise(userId);
            bool flag = false;
            int? randomIndex = null;
            while (flag == false)
            {
                randomIndex = new Random().Next(0, allWordsWithTranslation.Length - 1);
                for (int i = 0; i < userProfile.LearnedWords.Length; i++)
                {
                    string[] selectedWord = allWordsWithTranslation[(int)randomIndex].Split(separator);
                    if (userProfile.LearnedWords[i].Word == selectedWord[1]) flag = false;
                    else
                    {
                        flag = true;
                    }
                } 
            }
            return allWordsWithTranslation[(int)randomIndex];
        }

        public string GetOnlyEnglishWord(string wordWithTranslation)
        {
            return wordWithTranslation.Split(separator)[0];
        }

        public string[] GetTranslations(string wordWithTranslation)
        {
            string[] variantsOfTranslation = new string[4];
            int indexOfCorrectTranslation = new Random().Next(0, 3);
            string englishWord = wordWithTranslation.Split(separator)[0];
            string[] allWords = GetAllWords();
            variantsOfTranslation[indexOfCorrectTranslation] = englishWord.Split(separator)[1];
            for (int i = 0; i < 3; i++)
            {
                if (i != indexOfCorrectTranslation)
                {
                    string[] randomTranslation = allWords[new Random().Next(0, allWords.Length)].Split(separator);
                    variantsOfTranslation[i] = randomTranslation[1];
                }
            }
            return variantsOfTranslation;
        }

        public bool CheckAnswer(int number, string wordWithTranslation, string[] variantsOfTranslation)
        {
            string correctTranslation = wordWithTranslation.Split(separator)[1];
            int? correctAnswer = null;
            for (int i = 0; i < variantsOfTranslation.Length; i++)
            {
                if (correctTranslation == variantsOfTranslation[i])
                {
                    correctAnswer = i+1;
                    break;
                }
            }
            if (number == correctAnswer) return true;
            else return false;
        }

        public void SaveResultForSingleWord(bool checkedAnswer, int userId, string englishWordWithTranslation)
        {
            UserProfile userProfile = _userProfileRepository.GetOneProfile(userId);
            foreach (WordInProgress word in userProfile.WordsInProgress)
            {
                if (word.Word == englishWordWithTranslation.Split(separator)[0])
                {
                    word.NumberOfSuccessfulAttempts++;
                    if (word.NumberOfSuccessfulAttempts == 3) userProfile.AddLearnedWord(new LearnedWord(englishWordWithTranslation.Split(separator)[0], englishWordWithTranslation.Split(separator)[1]));
                    break;
                }
            }
        }

        public void UsingVocabularyService(int userId, int numberOfAnswer)
        {
            string wordWithTranslation = GetEnglishWordWithTranslation(userId);
            string englishWord = GetOnlyEnglishWord(wordWithTranslation);
            string[] translations = GetTranslations(wordWithTranslation);
            bool correctnessOfAnswer = CheckAnswer(numberOfAnswer, wordWithTranslation, translations);
            SaveResultForSingleWord(correctnessOfAnswer, userId, wordWithTranslation);
        }

        private readonly string _pathToFileWithWords;

        private readonly UserProfileRepository _userProfileRepository;

        private readonly char separator = ' ';

        private readonly int numberOfWordsInExercise = 15;
    }
}
