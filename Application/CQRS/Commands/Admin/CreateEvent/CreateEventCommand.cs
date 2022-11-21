using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.CQRS.Commands.Admin.CreateEvent
{
    public class CreateEventCommand : IRequest<int>
    {
        public CreateEventCommand(int ıd, string? title, string? description, string? ımage, int categoryId, int cityId, string? adress, int capacity, bool ticketNeeded, int? price, DateTime eventDate, DateTime applicationDeadline)
        {
            Id = ıd;
            Title = title;
            Description = description;
            Image = ımage;
            CategoryId = categoryId;
            CityId = cityId;
            Adress = adress;
            Capacity = capacity;
            TicketNeeded = ticketNeeded;
            Price = price;
            EventDate = eventDate;
            ApplicationDeadline = applicationDeadline;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string? Adress { get; set; }
        public int Capacity { get; set; }
        public bool TicketNeeded { get; set; }
        public int? Price { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }

    }

}
