using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Admin.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand,int>
    {
        private readonly IEventRepository _eventRepository;
        
        public UpdateEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
        }

        public async Task<int> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _eventRepository.GetById(request.Id);
            if (entity == null) return 0;
            
            entity.Title = request.Title;
            entity.Price = request.Price;
            entity.Description = request.Description;
            entity.EventDate = request.EventDate;
            entity.CategoryId = request.CategoryId;
            entity.CityId = request.CityId;
            entity.ApplicationDeadline = request.ApplicationDeadline;
            entity.Adress = request.Adress;
            entity.Capacity = request.Capacity;
            entity.Image = request.Image;
            entity.Status = request.Status;
            entity.TicketNeeded = request.TicketNeeded;
            entity.UpdatedAt = DateTime.Now;

            await _eventRepository.Update(entity);
            
            return request.Id;
        }
    }
}
