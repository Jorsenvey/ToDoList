using AutoMapper;
using TO_DO_List_Backend.Application.Contracts;
using TO_DO_List_Backend.Domain.Common;
using TO_DO_List_Backend.Domain.DataTransferObjects;
using TO_DO_List_Backend.Domain.Entities;
using TO_DO_List_Backend.Domain.InfraestructureContracts;


namespace TO_DO_List_Backend.Application.Services
{
    public class TaskApplication : ITaskApplication
    {
        private readonly IToDoListRepository _toDoListRepository;
        public readonly IMapper _mapper;
        public TaskApplication(IToDoListRepository toDoListRepository, IMapper mapper)
        {
            _toDoListRepository = toDoListRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Este metodo coloca la tarea en estado 3, que es el estado de eliminado y manda a actualizar la tarea en la tabla TasksList
        /// </summary>
        /// <param name="idTask"></param>
        /// <returns></returns>
        public async Task<int> DeletTask(int idTask)
        {
            TaskList taskList = await _toDoListRepository.GetTaskByIdAsync(idTask);
            taskList.IdEstatusTask = (int)eStatusTask.Deleted;
            return await _toDoListRepository.UpdateTaskListsAsync(taskList);
        }

        /// <summary>
        /// Este metodo obtiene todas las tareas excepto las eliminadas
        /// </summary>
        /// <returns></returns>
        public async Task<List<TaskListDto>> GetAllTask()
        {
            List<TaskList> taskList = await _toDoListRepository.GetTaskListsAsync();
            List<TaskListDto> taskListDto = Helper.Helper.ToListTaskListDto(taskList, _mapper);

            return taskListDto;
        }

        /// <summary>
        /// Este metodo actualiza la descripción de la tarea
        /// </summary>
        /// <param name="idTask"></param>
        /// <param name="descriptionTask"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> UdpdateDescriptionTask(int idTask, string descriptionTask, bool statusTask)
        {
            TaskList taskList = await _toDoListRepository.GetTaskByIdAsync(idTask);
            taskList.IdEstatusTask = Convert.ToInt32(Convert.ToByte(statusTask));
            taskList.DescriptionTask = descriptionTask;
            return await _toDoListRepository.UpdateTaskListsAsync(taskList);
        }

        /// <summary>
        /// Este metodo actualiza si la tarea se realiza o esta pendiente por hacer, ver enumerado eStatusTask, para compreder el estado de las tareas
        /// </summary>
        /// <param name="idTask"></param>
        /// <param name="idStatusTask"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> UdpdateStatusTask(int idTask, int idStatusTask)
        {
            TaskList taskList = await _toDoListRepository.GetTaskByIdAsync(idTask);
            taskList.IdEstatusTask = idStatusTask;
            return await _toDoListRepository.UpdateTaskListsAsync(taskList);
        }

        /// <summary>
        /// Crea una nueva tarea, solo recibe la descripción y la crea como tarea no realizada osea estado 2, 
        /// favor ver enumerado eStatusTask, para compreder el estado de las tareas
        /// </summary>
        /// <param name="descriptionTask"></param>
        /// <returns></returns>
        public async Task<int> AddTask(string descriptionTask)
        {
            TaskList taskList = new TaskList();
            taskList.IdEstatusTask = (int)eStatusTask.NotDone;
            taskList.DescriptionTask = descriptionTask;
            return await _toDoListRepository.AddTask(taskList);
        }
    }
}
