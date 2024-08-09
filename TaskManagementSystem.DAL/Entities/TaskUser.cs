using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.DAL.Entities
{
    public class TaskUser
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<TaskDetail> TaskDetails { get; set; }

    }
}
