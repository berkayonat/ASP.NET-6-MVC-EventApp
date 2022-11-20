using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Admin.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, int>
    {
        private readonly IEventRepository _eventRepository;
        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<int> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            await _eventRepository.Delete(request.Id);
            return request.Id;
        }
    }
}
