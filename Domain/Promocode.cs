using System;
using System.ComponentModel.DataAnnotations;

namespace ingressocom_promocodeAPI.Domain
{
    public class Promocode
    {
        [Required(ErrorMessage = "É obrigatório o uso de cupom.")]
        [Key]
        public string Id { get; set; }
        public string EndDate { get; set; }
        public PromocodeTypes Type { get; set; }
    }

    public enum PromocodeTypes {
        LOWER_PROMOCODE_DISCOUNT = 1,
        HIGHER_PROMOCODE_DISCOUNT = 2,
        FIXED_PROMOCODE_DISCOUNT = 3
    }
}