using Akaibu_Project.Entions;
using System.Collections.Generic;

namespace Akaibu_Project.Models
{
    public class ListsModel
    {
        public List<Status> Finished { get; set; }
        public List<Status> Watched { get; set; }
        public List<Status> Planned { get; set; }
    }
}
