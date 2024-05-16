using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Episods
    {
        //[Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Number { get; set; }
        public string Description { get; set; }
        public TimeSpan EpizodLenght { get; set; }
        public DateTime TehEoisodeWasAdded { get; set; }

        public DBAnime DBAnime { get; set; }
        public int DBAnimeId { get; set; }
        public List<Reports> Reports { get; set; } = new List<Reports>();
        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}
