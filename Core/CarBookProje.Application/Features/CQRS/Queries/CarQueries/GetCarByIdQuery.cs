using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery
    {
        public GetCarByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
