using System.ComponentModel.DataAnnotations;

namespace LanguageLearningAPI.Models
{
    public enum UserType
    {
        Admin,
        Learner
    }

    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public UserType UserType { get; set; }
    }
}
