using Application.CQRS.DTOs.Admin;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Admin.GetEventById
{
    public class GetEventByIdQuery : IRequest<EventDetailDto>
    {
        public int Id { get; set; }
        public GetEventByIdQuery(int id)
        {
            Id = id;
        }

        
    }
}
