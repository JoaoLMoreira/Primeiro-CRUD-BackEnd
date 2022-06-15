using System.ComponentModel.DataAnnotations;

namespace sistema.api.Models
{
    public class Cartao
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroDoCartao { get; set; }   
        public int MesDeExpiracao { get; set; }
        public int AnoDeExpiracao { get; set; }  
        public int CVC { get; set; }

    }
}
