using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public DateTime HoldPlaced { get; set; }


        public int LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }


        public int LibraryAssetId { get; set; }
        public LibraryAsset LibraryAsset { get; set; }
    }
}
