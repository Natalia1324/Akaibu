using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class DBAnime
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Author { get; set; }
        public string ShortStory { get; set; }
        public string Tag{ get; set; }
        public DateTime DateOfProductionStart { get; set; }
        public DateTime? DateOfProductionFinish { get; set; }
        public string StatusAnime { get; set; }

        public List<Comments> Comments { get; set; } = new List<Comments>();
        public ICollection<Reports> Reports { get; set;}
        public ICollection<Status> Status { get; set; }
    }
}
