using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public class UserProfile:IUserProfile
    {
        public UserProfile(int id, string nickname, LearnedWord[] learnedWords, WordInProgress[] wordsInProgress)
        {
            Id = id;
            Nickname = nickname;
            _learnedWords = new List<LearnedWord>(learnedWords ?? new LearnedWord[0]);
            _wordsInProgress = new List<WordInProgress>(wordsInProgress ?? new WordInProgress[0]);
        }

        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public LearnedWord[] LearnedWords
        {
            get
            {
                return _learnedWords.ToArray();
            }
        }
        public WordInProgress[] WordsInProgress
        {
            get
            {
                return _wordsInProgress.ToArray();
            }
        }

        public void AddLearnedWord(LearnedWord learnedWord)
        {
            _learnedWords.Add(learnedWord);
        }

        private List<LearnedWord> _learnedWords;
        private List<WordInProgress> _wordsInProgress;
    }
}
