using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City:BaseEntity
    {
        public string? Name { get; set; }
        public bool Status { get; set; } = false;

        public ICollection<Event>? Events { get; set; }
    }
}
