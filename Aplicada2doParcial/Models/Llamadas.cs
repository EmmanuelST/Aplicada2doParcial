using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2doParcial.Models
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        [Required(ErrorMessage ="Es necesaria una descripcion")]
        [StringLength(maximumLength:150,MinimumLength = 5,ErrorMessage ="La descripcion es muy larga o corta")]
        public string Descripcion { get; set; }
        
        [ForeignKey("LlamadaId")]
        public List<Casos> Casos { get; set; }

        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
            Casos = new List<Casos>();
        }
    }
}
