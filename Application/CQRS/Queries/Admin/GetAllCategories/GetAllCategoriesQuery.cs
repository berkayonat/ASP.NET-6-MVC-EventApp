using Application.CQRS.DTOs.Admin;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Admin.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoriesDto>>
    {
    }
}
