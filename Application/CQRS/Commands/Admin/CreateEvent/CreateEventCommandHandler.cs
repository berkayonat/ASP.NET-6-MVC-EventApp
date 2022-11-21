using Application.CQRS.Commands.Admin.UpdateEvent;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Admin.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new Event()
            {

                Title = request.Title,
                Price = request.Price,
                Description = request.Description,
                EventDate = request.EventDate,
                CategoryId = request.CategoryId,
                CityId = request.CityId,
                ApplicationDeadline = request.ApplicationDeadline,
                Adress = request.Adress,
                Capacity = request.Capacity,
                Image = request.Image,
                TicketNeeded = request.TicketNeeded,
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now
            };
        

            await _eventRepository.Add(entity);

            return request.Id;
        }

    }
}
