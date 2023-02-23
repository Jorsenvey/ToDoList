using System.ComponentModel.DataAnnotations;
using TO_DO_List_Backend.Domain.DataTransferObjects;

namespace TO_DO_List_Backend.Domain.Entities
{
    public class TaskList
    {
        [Key]
        public int IdTask { get; set; }
        public string DescriptionTask { get; set; }   
        public int IdEstatusTask { get; set; }
    }
}
