using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MovieRecomendation
{
    public class UserRegistration
    {
        public string AddUser(string nickname, string name, string surname, string mail)
        {
            User user = new User(nickname, name, surname, mail);
            string userSerialized = JsonConvert.SerializeObject(user);
            return userSerialized;
        }

        private void RecordUser(string userSerialized)
        {
            StreamWriter inputUser = new StreamWriter(Properties.Resources.UserData, true);
            inputUser.WriteLine(userSerialized);
            inputUser.Close();
        }
    }
}
