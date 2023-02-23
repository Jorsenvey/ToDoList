using TO_DO_List_Backend.Domain.Entities;

namespace TO_DO_List_Backend.Domain.InfraestructureContracts
{
    public interface IToDoListRepository
    {
        Task<List<TaskList>> GetTaskListsAsync();
        Task<TaskList> GetTaskByIdAsync(int id);
        Task<int> UpdateTaskListsAsync(TaskList taskList);
        Task<int> AddTask(TaskList taskList);
    }
}
