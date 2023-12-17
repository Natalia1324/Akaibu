using Akaibu_Project.Entions;
using System.Collections.Generic;

namespace Akaibu_Project.Models
{
    public class ListsModel
    {
        public ICollection<StatusModel> Finished { get; set; }
        public ICollection<StatusModel> Watched { get; set; }
        public ICollection<StatusModel> Planned { get; set; }
    }
}
