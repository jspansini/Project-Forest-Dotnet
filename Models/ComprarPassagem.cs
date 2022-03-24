using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaForest.Models
{
    public class ComprarPassagem
    {
        [Key]
        public  int IdPassagem { get; set; }

        public string? DestinoPassagem { get; set; }

        public double ValorPassagem { get; set; }

        [ForeignKey("CadastrarPassagem")]
        
        public int cadastrarPassagem { get; set; }

        public virtual CadastrarPassagem CadastrarPassagem { get; set; } 
    }
}
