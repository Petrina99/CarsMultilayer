using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsMultilayer.Common
{
    public class Paging
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public Paging() { }

        public Paging(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
