using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCarBook.Domain.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }

        public string Title { get; set; }

        public string Desciription { get; set; }

        public string IconUrl { get; set; }
    }
}
