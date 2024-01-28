using Akaibu_Project.Models;
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
        // 1 - admin
        // 0 - user
        // 69 - banned user
        public string Bans { get; set; }

        // Referensts
        public ICollection<Comments> Commensts { get; set; }
        public List<Reports> Reports { get; set; } = new List<Reports>();

        public ICollection<Status> Status { get; set; }
        // Properties
        [NotMapped]
        public bool isLogged { get; set; } = false;

        [NotMapped]
        public ListsModel lists { get; set; }

        [NotMapped]
        public SearchResults search { get; set; }
    }
}
