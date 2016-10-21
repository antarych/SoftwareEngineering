using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public class LearnedWord
    {
        public LearnedWord(string word, string translation)
        {
            Word = word;
            Translation = translation;
        }

        public static bool operator==(LearnedWord obj1, LearnedWord obj2)
        {
            return ((obj1.Word == obj2.Word) && (obj1.Translation ==obj2.Translation));
        }

        public static bool operator !=(LearnedWord obj1, LearnedWord obj2)
        {
            return !(obj1 == obj2);
        }

        public string Word { get; private set; }
        public string Translation { get; private set; }
    }
}
