﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Reports
    {
        public Guid Id { get; set; }
        public string ReportText { get; set; }
        public DateTime DateTheReportWasAdded { get; set; }

        public DBAnime DBAnime { get; set; }
        public int DBAnimeId { get; set; }
        public Users Users { get; set; }
        public int UsersId { get; set; }
        public Comments Comments { get; set; }
        public Guid CommentsId { get; set;}
        public Episods Episods { get; set; }
        public Guid EpisodsId { get; set; }

    }
}
