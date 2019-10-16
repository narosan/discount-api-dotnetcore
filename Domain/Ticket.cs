using System.ComponentModel.DataAnnotations;

namespace ingressocom_promocodeAPI.Domain
{
    public class Ticket
    {
        [Required(ErrorMessage = "Identificador do ticket é obrigatório.")]
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [Range(typeof(decimal), "0", "50000")]
        public decimal Price { get; set; }
    }
}