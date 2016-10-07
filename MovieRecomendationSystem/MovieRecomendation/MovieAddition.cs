using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace MovieRecomendation
{
    public class MovieAddition
    {
        public string[] OneMovieAddition(string nickname, string title, string director, Genres genre, double rating)
        {
            Movie film = new Movie(title, director, genre, rating);
            string filmSerialized = JsonConvert.SerializeObject(film);
            string[] usersFilm = new string[] { nickname, filmSerialized, DateTime.Today.ToString("d") };
            return usersFilm;
        }

        private void AddMovieToGeneralList(string[] userFilm)
        {
            StreamReader outputMovies = new StreamReader(Properties.Resources.FilmsData);
            string generalListString = outputMovies.ReadToEnd();
            outputMovies.Close();
            List<string[]> generalListDeserialized = JsonConvert.DeserializeObject<List<string[]>>(generalListString);
            if (generalListDeserialized == null)
            generalListDeserialized.Add(userFilm);
            string generalListSerialized = JsonConvert.SerializeObject(generalListDeserialized);
            StreamWriter inputMovies = new StreamWriter(Properties.Resources.UserData, false);
            inputMovies.WriteLine(generalListSerialized);
            inputMovies.Close();
        }
    }
}
