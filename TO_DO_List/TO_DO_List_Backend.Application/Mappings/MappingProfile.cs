using AutoMapper;
using TO_DO_List_Backend.Domain.DataTransferObjects;
using TO_DO_List_Backend.Domain.Entities;

namespace TO_DO_List_Backend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskListDto, TaskList>().ReverseMap()
                .ForMember(dest => dest.IdTask, opt => opt.MapFrom(j => j.IdTask))
                .ForMember(dest => dest.DescriptionTask, opt => opt.MapFrom(j => j.DescriptionTask))
                .ForMember(dest => dest.IdEstatusTask, opt => opt.MapFrom(j => j.IdEstatusTask));
        }
    }
}
