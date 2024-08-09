using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options ) : base( options ) 
        { 
        }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<TaskUser> TaskUsers { get; set; }
    }
}
