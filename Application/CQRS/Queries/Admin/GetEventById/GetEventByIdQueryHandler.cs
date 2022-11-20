using Application.CQRS.DTOs.Admin;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Admin.GetEventById
{
    public class GetEventByIdQueryHandler: IRequestHandler<GetEventByIdQuery, EventDetailDto>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public GetEventByIdQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventDetailDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _eventRepository.GetEventByIdWithInclude(request.Id);
            return _mapper.Map<EventDetailDto>(entity);
        }
    }
}
