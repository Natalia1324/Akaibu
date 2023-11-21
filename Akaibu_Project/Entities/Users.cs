using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Entions
{
    public class Users
    {
        [Key] public int ID_USER { get; set; }
        public string Nick { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Ranks { get; set; }

        // Properties
    }
}
