using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string? Adress { get; set; }
        public string? Duration { get; set; }
        public int Capacity { get; set; }
        public int UserId { get; set; }
        public bool TicketNeeded { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; } = false;
        public DateTime EventDate { get; set; }
        public DateTime ApplicationDeadline { get; set; }
    }
}
