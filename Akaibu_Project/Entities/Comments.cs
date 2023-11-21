using System;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Comments
    {
        [Key] public int ID_COMMENT { get; set; }
        public int ID_ANIME { get; set; }
        public int ID_USER { get; set; }
        public DateTime Date_The_comment_was_added { get; set; }
        public string Comment_Text { get; set; }
        public string My_rating { get; set; }
        
    }
}
