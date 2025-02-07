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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, Unit>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.TestimonialID);
            values.Name = request.Name;
            values.Title = request.Title;
            values.Comment = request.Comment;
            values.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(values);
            return Unit.Value;

        }
    }
}
