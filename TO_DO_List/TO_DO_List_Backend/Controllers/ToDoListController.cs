using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TO_DO_List_Backend.Application.Contracts;

namespace TO_DO_List_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ITaskApplication _taskApplication;
        public ToDoListController(ITaskApplication taskApplication)
        {
            _taskApplication = taskApplication;
        }


        [HttpGet]
        [Route("GetAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            var response = await _taskApplication.GetAllTask();
            return Ok(response);
        }

        [HttpPost]
        [Route("UpdateDescriptionTask")]
        public async Task<IActionResult> UpdateDescriptionTask(int idTask, string descriptionTask, bool statusTask)
        {
            var response = await _taskApplication.UdpdateDescriptionTask(idTask, descriptionTask, statusTask);
            return Ok(response);
        }

        [HttpPost]
        [Route("UdpdateStatusTask")]
        public async Task<IActionResult> UdpdateStatusTask(int idTask, int idStatusTask)
        {
            var response = await _taskApplication.UdpdateStatusTask(idTask, idStatusTask);
            return Ok(response);
        }

        [HttpPost]
        [Route("DeletTask")]
        public async Task<IActionResult> DeletTask(int idTask)
        {
            var response = await _taskApplication.DeletTask(idTask);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddTask")]
        public async Task<IActionResult> AddTask(string descriptionTask)
        {
            var response = await _taskApplication.AddTask(descriptionTask);
            return Ok(response);
        }
    }
}
