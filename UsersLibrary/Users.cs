using System.ComponentModel.DataAnnotations;

namespace UsersLibrary
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a username.", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.", AllowEmptyStrings = false)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Passwd { get; set; }
    }
}
