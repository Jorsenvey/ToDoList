using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TO_DO_List_Backend.Persistence.DataAcces;

namespace TO_DO_List_Backend.Extencions
{
    public static class ServiceExtencions
    {    
        public static IServiceCollection AddDbContextExtencion(this IServiceCollection services)
        {
            services.AddDbContextPool<ToDoListDbContex>(options =>
            {
                options.UseSqlServer("Data Source=LAPTOP-J04DF1IS;Initial Catalog=ToDoList;Integrated Security=True;TrustServerCertificate=True;Encrypt=False");
            });
            return services;
        }
    }
}
