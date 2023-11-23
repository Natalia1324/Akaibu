using System;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Reports
    {
        public Guid Id { get; set; }
        public string Report_Text { get; set; }
        public DateTime Date_The_Report_was_added { get; set; }

        public DBAnime DBAnime { get; set; }
        public int DBAnimeId { get; set; }
        public Users Users { get; set; }
        public int UsersId { get; set; }
    }
}
