using Akaibu_Project.Entions;

namespace Akaibu_Project.Models
{
    public class AccountModel
    {
        public Users user {  get; set; }
        public int FinishedCount {  get; set; }
        public int WatchedCount { get; set; }
        public int PlannedCount { get; set; }
    }
}
