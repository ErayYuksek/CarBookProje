using CarBookProje.Application.Features.Mediator.Queries.ServiceQueries;
using CarBookProje.Application.Features.Mediator.Results.ServiceResults;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.ServiceHandler
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                Desciription = x.Desciription,
                IconUrl = x.IconUrl,
                ServiceID = x.ServiceID,
                Title = x.Title
            }).ToList();
        }
    }
}

//Evet, tam olarak! Veriler genelde gerekli olanları göstermek ve daha düzenli bir şekilde sunmak için dönüştürülür. İşte özet:

//Kullanıcıya sade veri sunmak: Veritabanındaki tüm bilgileri göstermek yerine, sadece kullanıcının veya uygulamanın ihtiyacı olan bilgileri döneriz.

//Fazlalıkları gizlemek: Gereksiz ya da hassas bilgileri gizleyerek daha güvenli ve temiz bir veri sağlarız.

//Daha kolay kullanım: Dönüştürülmüş veri, istemci (frontend veya başka bir sistem) tarafından kolayca işlenebilir.

//Örnek:

//Veritabanında 10 alan varsa ama kullanıcıya sadece 3 alan lazımsa, bu dönüşüm yapılarak sadece bu 3 alan döndürülür. 😊





