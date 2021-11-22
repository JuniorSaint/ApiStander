using System;
using System.ComponentModel.DataAnnotations;
using Api.Application.Dtos.Event;

namespace Api.Application.Dtos.Lot
{
    public class LotDto
    {
        public Guid Id { get; set; }

        public string LotName { get; set; }

        public decimal Price { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Amount { get; set; }

        public Guid EventId { get; set; }
        public EventDto EventDto { get; set; }

        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
    }
}

