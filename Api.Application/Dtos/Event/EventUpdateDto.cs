using System.ComponentModel.DataAnnotations;
using Api.Application.Dtos.Lot;
using Api.Application.Dtos.SocialMedia;
using Api.Application.Dtos.Speaker;

namespace Api.Application.Dtos.Event
{
    public class EventUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Display(Name = "Local do Evento"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Local { get; set; }

        [Display(Name = "Data do Evento"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Hora do Evento"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public TimeSpan EventTime { get; set; }

        [Display(Name = "Tema"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        public string Theme { get; set; }

        [Display(Name = "Quantidade de pessoas"),
         Required(ErrorMessage = "O campo {0} é obrigtório.")]
        [Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]
        public int PeopleAmount { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
         ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string EventImage { get; set; }

        [Display(Name = "Telefone"),
            Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "e-mail")]
        [RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo email com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Id do Usuário")]
        public Guid IdUser { get; set; }

        public IEnumerable<LotDto> Lots { get; set; }
        public IEnumerable<SocialMediaDto> socialMedias { get; set; }
        public IEnumerable<SpeakerDto> Speakers { get; set; }

    }
}

