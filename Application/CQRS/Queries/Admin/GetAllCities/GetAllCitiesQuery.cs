using Application.CQRS.DTOs.Admin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Admin.GetAllCities
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<CitiesDto>>
    {
    }
}
