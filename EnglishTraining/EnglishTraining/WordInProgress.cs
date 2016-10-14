using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public class WordInProgress
    {
        public WordInProgress(string word, int numberOfSuccessfulAttempts)
        {
            Word = word;
            NumberOfSuccessfulAttempts = numberOfSuccessfulAttempts;
        }

        public string Word { get; private set; }
        public int NumberOfSuccessfulAttempts { get; set; }
    }
}
