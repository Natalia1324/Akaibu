﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Comments
    {
        //[Required]
        public int Id { get; set; }
        public DateTime DateTheCommentWasAdded { get; set; }
        public string Comment_Text { get; set; }
        public string MyRating { get; set; }

        public DBAnime DBAnime { get; set; }
        public int DBAnimeId { get; set; }
        public Users Users { get; set; }
        public int UsersId { get; set; }


       // public Users user { get; set; }
       // public DB_ANIME aniem { get; set; }

    }
}
