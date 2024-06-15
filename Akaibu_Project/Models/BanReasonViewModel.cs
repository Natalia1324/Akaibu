using System.ComponentModel.DataAnnotations;

namespace Akaibu_Project.Models
{
    public class BanReasonViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Powód bana jest wymagany.")]
        public string Reason { get; set; }
    }
}
