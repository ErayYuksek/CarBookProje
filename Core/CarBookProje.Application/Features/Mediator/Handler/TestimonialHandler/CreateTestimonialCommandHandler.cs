using CarBookProje.Application.Features.Mediator.Commands.SocialMediaCommand;
using CarBookProje.Application.Features.Mediator.Commands.TestimonialCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TestimonialHandler
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand, Unit>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
         await _repository.CreateAsync(new Testimonial
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Comment = request.Comment,
                Title = request.Title,
            }
           );
            return Unit.Value;
        }
    }
}
