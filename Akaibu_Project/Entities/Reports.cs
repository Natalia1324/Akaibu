using System;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Reports
    {
        [Key] public int ID_Reports { get; set; }
        public int ID_USER { get; set; }
        public int ID_ANIME { get; set; }
        public string Report_Text { get; set; }
        public DateTime Date_The_Report_was_added { get; set; }
    }
}
