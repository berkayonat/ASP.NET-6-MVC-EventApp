using Domain.Entities;

namespace Application.CQRS.DTOs.Admin
{
    public class EventDto
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public string? EventCategory { get; set; }
        public string? EventCity { get; set; }
        public bool Status { get; set; } = false;
        public DateTime EventDate { get; set; }

        public Category? Category { get; set; }
        public City? City { get; set; }
    }
}