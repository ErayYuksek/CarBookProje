using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace UCarBook.Domain.Entities
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public List<Car> Cars { get; set; }
    }
}
