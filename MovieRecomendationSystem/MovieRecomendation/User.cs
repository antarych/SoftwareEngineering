using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MovieRecomendation
{
    public class User
    {
        public User(string nickname, string name, string surname, string mail)
        {
            Nickname = nickname;
            Name = name;
            Surname = surname;
            Mail = mail;
        }

        public string Nickname { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Mail { get; private set; }
        
    }
}
