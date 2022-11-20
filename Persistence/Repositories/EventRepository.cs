using Application.CQRS.DTOs.Admin;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly AppDbContext _context;
        public EventRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsWithCategoryAndCity()
        {
            return await _context.Events.Include(a => a.City).Include(a => a.Category)
                .Select(a => new EventDto()
                {
                    Id = a.Id,
                    Title = a.Title,
                    EventCategory = a.Category.Name,
                    EventCity = a.City.Name,
                    EventDate = a.EventDate,
                    Status = a.Status
                }).ToListAsync();
        }
    }
}
