using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public interface IUserProfile
    {
        int Id { get; }
        string Nickname { get; }
        LearnedWord[] LearnedWords { get; }
        void AddLearnedWord(LearnedWord word);
    }
}
