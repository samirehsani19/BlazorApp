using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{2, 20}$", ErrorMessage = "Please choose a valid name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]{2, 20}$", ErrorMessage = "Please choose a valid name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[a-z0-9A-Z]{5, 30}.(com | se)$", ErrorMessage = "Please choose a valid Email")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Please choose a longer password")]
        public string Password { get; set; }
        public ICollection<Todo> Todos { get; set; }
        public ICollection<Diary> Diaries { get; set; }
    }
}
