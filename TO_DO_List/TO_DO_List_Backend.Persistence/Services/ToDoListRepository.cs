using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TO_DO_List_Backend.Domain.Common;
using TO_DO_List_Backend.Domain.Entities;
using TO_DO_List_Backend.Domain.InfraestructureContracts;
using TO_DO_List_Backend.Persistence.DataAcces;

namespace TO_DO_List_Backend.Persistence.Services
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ToDoListDbContex _context;
        public ToDoListRepository(ToDoListDbContex context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las tareas excepto las que estan en estado 3, que son la eliminadas
        /// </summary>
        /// <returns></returns>
        public async Task<List<TaskList>> GetTaskListsAsync()
        {
            try
            {
                int deleted = (int)eStatusTask.Deleted;
                return await _context.TasksList.Where(d => d.IdEstatusTask != deleted).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Este metodo se encarga de actualizar la tarea, aqui se puede cambiar de nombre la tarea y tambien se puede cambiar el estado de la tarea
        /// Favor ver el enumerado eStatusTask, aca estan definidos los estados de la tareas
        /// </summary>
        /// <param name="taskList"></param>
        /// <returns></returns>
        public async Task<int> UpdateTaskListsAsync(TaskList taskList)
        {
            try
            {
                _context.TasksList.Update(taskList);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Este metodo se encarga de crear las tareas
        /// </summary>
        /// <param name="taskList"></param>
        /// <returns></returns>
        public async Task<int> AddTask(TaskList taskList)
        {
            try
            {
                taskList.IdEstatusTask = (int)eStatusTask.NotDone;
                await _context.TasksList.AddAsync(taskList);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtiene la tarea por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TaskList> GetTaskByIdAsync(int id)
        {
            try
            {              
                return await _context.TasksList.Where(e => e.IdTask == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
