using System.ComponentModel.DataAnnotations;

namespace TM.API.Models
{
    public class TimeInput{

        public int Id {get;set;}

        [Required]
        public int ProjectId {get;set;}
        public Project Project {get;set;}
        
        [Required]
        public decimal TimeSpent {get;set;}
    }
}