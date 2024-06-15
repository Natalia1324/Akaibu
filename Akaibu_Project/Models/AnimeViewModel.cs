using Akaibu_Project.Entions;
using System.Collections.Generic;

namespace Akaibu_Project.Models
{
    public class AnimeViewModel
    {
        public DBAnime Anime { get; set; }
        public List<Episods> Episodes { get; set; }
    }

}
