using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace EnglishTraining
{
    public class UserProfileRepository:IRepository<UserProfile>
    {
        public UserProfileRepository(string pathToUserDataFile)
        {
            _pathToUserDataFile = pathToUserDataFile;
        }

        public void SaveProfile(UserProfile userProfile)
        {
            List<UserProfile> userProfiles = new List<UserProfile>(GetAllProfiles());
            userProfiles.Add(userProfile);
            string serializedProfiles = JsonConvert.SerializeObject(userProfiles);
            File.WriteAllText(_pathToUserDataFile, serializedProfiles);
        }

        public UserProfile[] GetAllProfiles()
        {
            string serializedProfiles = File.ReadAllText(_pathToUserDataFile);
            UserProfile[] allProfiles = JsonConvert.DeserializeObject<UserProfile[]>(serializedProfiles);
            return allProfiles;
        }

        public UserProfile GetOneProfile(int userId)
        {
            UserProfile[] allProfiles = GetAllProfiles();
            int? indexOfProfile = null;
            for (int i = 0; i < allProfiles.Length; i++)
            {
                if (allProfiles[i].Id == userId)
                {
                    indexOfProfile = i;
                    break;
                }
            }
            return allProfiles[(int)indexOfProfile];
        }


        private readonly string _pathToUserDataFile;
    }
}
