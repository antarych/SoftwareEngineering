using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public interface IVocabularyService
    {
        string[] GetWordsForExercise();

        string GetEnglishWordWithTranslation(int userId);

        string GetOnlyEnglishWord(string wordWithTranslation);

        string[] GetTranslations(string wordWithTranslation);

        bool CheckAnswer(int number, string wordWithTranslation, string[] variantsOfTranslation);

        void SaveResultForSingleWord(bool checkedAnswer, int userId, string englishWordWithTranslation);

        void UsingVocabularyService(int userId, int numberOfAnswer);
    }
}
