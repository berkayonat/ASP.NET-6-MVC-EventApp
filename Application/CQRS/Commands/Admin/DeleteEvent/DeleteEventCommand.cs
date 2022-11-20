using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands.Admin.DeleteEvent
{
    public class DeleteEventCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteEventCommand(int id)
        {
            Id = id;    
        }
    }
}
