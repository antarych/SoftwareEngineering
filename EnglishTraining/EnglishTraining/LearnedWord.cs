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

        public string Word { get; private set; }
        public string Translation { get; private set; }
    }
}
