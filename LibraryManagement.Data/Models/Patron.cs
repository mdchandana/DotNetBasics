using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class Patron
    {
        public int Id { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Address { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        [Required] public string Email { get; set; }
        public string Telephone { get; set; }


      
        public LibraryCard LibraryCard { get; set; }  //1:1


        public LibraryBranch HomeLibraryBranch { get; set; } 
    }
}
