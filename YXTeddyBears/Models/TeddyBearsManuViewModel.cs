using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace YXTeddyBears.Models
{
    public class TeddyBearsManuViewModel
    {
        public List<TeddyBears> TeddyBears { get; set; }
        public SelectList Manufacturer { get; set; }
        public string TeddyBearManu { get; set; }

        public string SearchString { get; set; }
    }
}
