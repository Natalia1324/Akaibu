using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akaibu_Project.Models
{
    public class Anime_DB
    {

        public IList<string> Title { get; set; }
        public string Type { get; set; }
        public int Episodes { get; set; }
        public string Status { get; set; }
        public AnimeSeason AnimeSeason { get; set; }
        public string Picture { get; set; }
        public string Thumbnail { get; set; }
        public IList<string> Synonyms { get; set; }
        public IList<string> Relations { get; set; }
        public IList<string> Tags { get; set; }
        public Anime_DB()
        {

        }

    }

    public class AnimeSeason
    {
        public string Season { get; set; }
        public int Year { get; set; }
        public AnimeSeason()
        {

        }
    }
}
