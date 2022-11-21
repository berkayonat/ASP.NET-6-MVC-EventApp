using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.DTOs.Admin
{
    public class EventDetailDto
    {   
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string? Adress { get; set; }
        public int Capacity { get; set; }
        public AppUser? AppUser { get; set; }
        public bool TicketNeeded { get; set; }
        public int? Price { get; set; }
        public bool Status { get; set; } = false;
        public DateTime EventDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
