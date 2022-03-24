using System.ComponentModel.DataAnnotations;

namespace AgenciaForest.Models
{
    public class CadastrarPassagem
    {
        [Key]
        public int IdPassagem { get; set; }

        public string? DestinoPassagem { get; set;}

        public double ValorPassagem { get; set;}


    }

  
}
