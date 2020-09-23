using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TM.API.Models
{
    public class Customer{

        public int Id {get;set;}

        [Required]
        public string Name {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
    }
}