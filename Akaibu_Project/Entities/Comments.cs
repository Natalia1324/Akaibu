using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Comments
    {
        //[Required]
        public Guid Id { get; set; }
        public DateTime DateTheCommentWasAdded { get; set; }
        public string CommentText { get; set; }
        public string MyRating { get; set; }

        public DBAnime DBAnime { get; set; }
        public int DBAnimeId { get; set; }
        public Users Users { get; set; }
        public int UsersId { get; set; }
        public List<Reports> Reports { get; set; } = new List<Reports>();
        public Episods Episods { get; set; }
        public Guid? EpisodsId { get; set;}
        
    }
}
