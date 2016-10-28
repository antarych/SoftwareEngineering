using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTraining
{
    public class RegistrationService:IRegistrationService
    {
        public RegistrationService(IRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int AddUser(string nickname)
        {
            int newId = CreateNewId();
            var newProfile = new UserProfile(newId, nickname, new LearnedWord[0], new WordInProgress[0]);
            return newId;
        }

        public int CreateNewId()
        {
            return _userProfileRepository.GetAllProfiles().Length + 1;
        }

        private readonly IRepository<UserProfile> _userProfileRepository;
    } 
}
