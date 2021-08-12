using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class Checkout
    {
        public int Id { get; set; }

                  
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

        public int LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }


        public int LibraryAssetId { get; set; }
        public LibraryAsset LibraryAsset { get; set; }
    }
}
