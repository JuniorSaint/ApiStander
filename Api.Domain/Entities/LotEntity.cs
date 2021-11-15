using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class LotEntity : BaseEntities
    {
        public string LotName { get; set; }

        public decimal Price { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Amount { get; set; }

        public Guid EventId { get; set; }
        public EventEntity Event { get; set; }
    }
}

