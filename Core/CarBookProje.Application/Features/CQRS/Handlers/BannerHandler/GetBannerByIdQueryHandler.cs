using CarBookProje.Application.Features.CQRS.Queries.BannerQueries;
using CarBookProje.Application.Features.CQRS.Results.BannerResults;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.BannerHandler
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            if (values == null)
            {
                throw new Exception("Banner not found."); // Eğer veri bulunmazsa hata verir.
            }

            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Title = values.Title,
                Description = values.Description,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl
            };
        }

    }
}
