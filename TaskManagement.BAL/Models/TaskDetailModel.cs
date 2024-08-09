using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.BAL.Models
{
    public class TaskDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }     
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TaskUserId { get; set; }
    }
}
