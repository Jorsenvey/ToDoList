using Microsoft.EntityFrameworkCore;
using TO_DO_List_Backend.Domain.Entities;

namespace TO_DO_List_Backend.Persistence.DataAcces
{
    public partial class ToDoListDbContex : DbContext
    {
        public ToDoListDbContex(DbContextOptions options) : base(options) { }

        public virtual DbSet<TaskList> TasksList { get; set; }
    }
}
