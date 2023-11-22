using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class DB_ANIME
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public int Number_of_episodes { get; set; }
        public string Author { get; set; }
        public string Short_Story { get; set; }
        public string TAG { get; set; }
        public DateTime Date_of_productionStart { get; set; }
        public DateTime? Date_of_productionFinish { get; set; }
        public string Status { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}
