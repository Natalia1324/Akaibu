using System;

namespace Akaibu_Project.Entions
{
    public class DB_ANIME
    {
        public int ID_ANIME { get; set; }
        public string Title { get; set; }
        public int Number_of_episodes { get; set; }
        public string Author { get; set; }
        public string Short_Story { get; set; }
        public string TAG { get; set; }
        public DateTime Date_of_production { get; set; }
        public string Status { get; set; }
    }
}
