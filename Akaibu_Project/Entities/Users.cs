using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Users
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Ranks { get; set; }

        // Referensts
        public Comments Commensts { get; set; }
        public int CommenstsId { get; set; }
        // Properties
    }
}
