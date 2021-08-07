using CleerenCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.ViewModels
{
    public class PieListVM
    {
        public string CurrentCategory { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
