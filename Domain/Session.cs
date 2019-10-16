using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ingressocom_promocodeAPI.Domain
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Evento obrigatório.")]
        public Event Event { get; set; }
        [Required(ErrorMessage = "Local do evento obrigatório.")]
        public Theatre Theatre { get; set; }
        [Required(ErrorMessage = "Data da sessão obrigatória.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "É obrigatório o envio de ingressos.")]
        public List<Ticket> Tickets { get; set; }
    }
}