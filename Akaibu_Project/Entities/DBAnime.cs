using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akaibu_Project.Entions
{
    public class DBAnime
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }
        public string Title { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Author { get; set; }
        public string ShortStory { get; set; }
        public string Tag{ get; set; }
        public DateTime DateOfProductionStart { get; set; }
        public DateTime? DateOfProductionFinish { get; set; }
        public string StatusAnime { get; set; }

        public List<Episods> Episods { get; set; } = new List<Episods>();
        public List<Comments> Comments { get; set; } = new List<Comments>();
        public List<Reports> Reports { get; set; } = new List<Reports>();
        public List<Status> Status { get; set; } = new List<Status>();
    }
}
