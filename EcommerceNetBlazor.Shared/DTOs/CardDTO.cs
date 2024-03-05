using System.ComponentModel.DataAnnotations;

namespace EcommerceNetBlazor.Shared.DTOs
{
    public class CardDTO
    {
        [Required(ErrorMessage = "Ingrese Titular")]
        public string? Headline { get; set; }
        [Required(ErrorMessage = "Ingrese Numerro tarjeta")]
        public string? Number { get; set; }
        [Required(ErrorMessage = "Ingrese Vigencia")]
        public string? Validity { get; set; }
        [Required(ErrorMessage = "Ingrese CVV")]
        public string? CVV { get; set; }
    }
}
