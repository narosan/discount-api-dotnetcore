using System.ComponentModel.DataAnnotations;

namespace ingressocom_promocodeAPI.Domain
{
    public class Theatre
    {
        [Required(ErrorMessage = "Identificador do cinema é obrigatório.")]
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public bool isContemplated { get; set; }
    }
}