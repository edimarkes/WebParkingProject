using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebParking.Models
{
    public class ControleVeiculo
    {
        [Key]
        [Required]
        public string? Condutor { get; set; }
        [Required]
        public string? Placa { get; set; }
        [Required]
        public string? Veiculo { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public string? Cor { get; set; }
        [Required]
        [Display(Name = "Entrada")]
        public DateTime HoraEntrada { get; set; }
        [Required]
        [Display(Name = "Saída")]
        public DateTime HoraSaida { get; set; }
       
        [Display(Name = "Valor Pago")]
        public decimal ValorPago { get; set; }
    }
}
