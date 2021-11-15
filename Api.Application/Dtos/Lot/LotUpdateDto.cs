using System;
using System.ComponentModel.DataAnnotations;
using Api.Application.Dtos.Event;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Dtos.Lot
{
    public class LotUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Display(Name = "Nome do lote"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string LotName { get; set; }

        [Display(Name = "Preço"),
         Required(ErrorMessage = "O campo {0} é obrigtório."),
         Precision(10, 2)]
        public decimal Price { get; set; }

        [Display(Name = "Data inicial"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Data final"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Quantidade"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public int Amount { get; set; }

        [Display(Name = "Id do evento"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public Guid EventId { get; set; }
        public EventDto EventDto { get; set; }
    }
}

