using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akaibu_Project.Entions
{
    public class Status
    {

        public int ID_USER { get; set; }
        public int ID_ANIME { get; set; }

        [ForeignKey("ID_USER")]
        public Users User { get; set; }

        [ForeignKey("ID_ANIME")]
        public DBAnime Anime { get; set; }

        public int Last_Epizod { get; set; }
        public string status {  get; set; }
    }
}
