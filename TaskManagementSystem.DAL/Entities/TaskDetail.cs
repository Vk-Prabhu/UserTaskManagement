using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.DAL.Entities
{
    public class TaskDetail
    {
        [Key]
        [Required]
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? CreatedOn { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? UpdatedOn { get; set; }
        public TaskUser TaskUser { get; set; }  //Fk for User

        public int TaskUserId { get; set; }
    }
}
