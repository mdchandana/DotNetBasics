using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string DeweyIndex { get; set; }
    }
}
