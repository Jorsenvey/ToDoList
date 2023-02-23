using System.Threading.Tasks;
using TO_DO_List_Backend.Domain.Common;
using TO_DO_List_Backend.Domain.DataTransferObjects;
using TO_DO_List_Backend.Domain.Entities;

namespace TO_DO_List_Backend.Application.Contracts
{
    public interface ITaskApplication
    {
        Task<List<TaskListDto>> GetAllTask();
        Task<int> UdpdateDescriptionTask(int idTask, string descriptionTask, bool statusTask);
        Task<int> UdpdateStatusTask(int idTask, int idStatusTask);
        Task<int> DeletTask(int idTask);
        Task<int> AddTask(string descriptionTask);
    }
}
