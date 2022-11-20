using Application.CQRS.DTOs.Admin;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Admin.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<EventDto>>
    {
        private readonly IEventRepository _eventRepository;
        

        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
        }

        public async Task<IEnumerable<EventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllEventsWithCategoryAndCity();
            return events;
        }
    }
}
