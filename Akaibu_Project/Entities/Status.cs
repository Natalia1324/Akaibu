using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akaibu_Project.Entions
{
    public class Status
    {   
        public Users Users { get; set; }
        public int UsersId { get; set; }

        public DBAnime DBAnime { get; set; }
        public int DBAnimeId { get; set; }

        public int? LastEpizod { get; set; }
        public string StatusValue {  get; set; }
    }
}
