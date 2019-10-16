using System;
using System.ComponentModel.DataAnnotations;

namespace ingressocom_promocodeAPI.Domain
{
    public class Checkout
    {
        [Required(ErrorMessage = "Identificador da ordem de compra é obrigatório.")]
        [Key]
        public string _id { get; set; }
        [Range(typeof(decimal), "0", "50000")]
        public decimal TotalPrice { get; set; }
        [Required(ErrorMessage = "Data da ordem de compra é obrigatória.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Uma sessão é obrigatória.")]
        public Session Sessions { get; set; }
        [Required(ErrorMessage = "É obrigatório o uso de cupom.")]
        public string Promocode { get; set; }
        public bool isContemplated { get; set; }
    }
}