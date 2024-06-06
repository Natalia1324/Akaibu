using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akaibu_Project.Entions
{
    public class Users
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Ranks { get; set; }
        public string Bans {  get; set; }

        // Referensts
        public List<Comments> Commensts { get; set; } = new List<Comments>();
        public List<Reports> Reports { get; set; } = new List<Reports>();

        public List<Status> Status { get; set; } = new List<Status>();
        // Properties
        [NotMapped]
        public bool isLogged { get; set; } = false;
    }
}
