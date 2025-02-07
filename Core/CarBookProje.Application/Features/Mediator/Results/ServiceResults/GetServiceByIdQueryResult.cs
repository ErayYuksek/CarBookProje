using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public int ServiceID { get; set; }

        public string Title { get; set; }

        public string Desciription { get; set; }

        public string IconUrl { get; set; }
    }
}
