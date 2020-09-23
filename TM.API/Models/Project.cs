using System.ComponentModel.DataAnnotations;

namespace TM.API.Models
{
    public class Project{

        public int Id {get;set;}

        [Required]
        public string Name {get;set;}

        public string Description {get;set;}

        [Required]
        public int CustomerId {get;set;}
        public Customer Customer {get;set;}

    }
}