using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMultilayer.Common
{
    public class Sorting
    {
        public string? OrderBy { get; set; }
        public string? SortOrder { get; set; }
        public Sorting() { }
        public Sorting(string? orderBy, string? sortOrder)
        {
            OrderBy = orderBy;
            SortOrder = sortOrder;
        }
    }
}
