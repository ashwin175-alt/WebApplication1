using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserRegModel
    {
        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [Required]
        [DisplayName("Email ID")]
        public string  ?emailid { get; set; }

        [Required]
        [DisplayName("User Password")]
        public string ?password { get; set; }

        [Required]
        [DisplayName("UserName")]
        public string ?name { get; set; }
    }
}
