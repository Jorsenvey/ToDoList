using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO_DO_List_Backend.Domain.DataTransferObjects;
using TO_DO_List_Backend.Domain.Entities;

namespace TO_DO_List_Backend.Application.Helper
{
    public static class Helper
    {
        public static List<TaskListDto> ToListTaskListDto(List<TaskList> listTask, IMapper mapper)
        {
            List<TaskListDto> taskListDtos = new List<TaskListDto>();
            //Define the mapping
            //var _mappedUser = _mapper.Map<User>(user);
            foreach (var item in listTask)
            {
                TaskListDto dto = mapper.Map<TaskListDto>(item);
                taskListDtos.Add(dto);
            }
            return taskListDtos;
        }
    }
}
