using System;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Comments
    {
        //[Required]
        public int Id { get; set; }
        
        public int ID_USER { get; set; }
        public DateTime Date_The_comment_was_added { get; set; }
        public string Comment_Text { get; set; }
        public string My_rating { get; set; }

        public DB_ANIME DB_ANIME { get; set; }
        public int DB_ANIMEId {  get; set; }
        public Users Users { get; set; }
        public int UserId { get; set; }


       // public Users user { get; set; }
       // public DB_ANIME aniem { get; set; }

    }
}
