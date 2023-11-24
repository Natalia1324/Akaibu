using System;
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
    }
}
