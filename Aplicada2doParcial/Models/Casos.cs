using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicada2doParcial.Models
{
    public class Casos
    {
        [Key]
        public int CasoId { get; set; }
        public int LlamadaId { get; set; }
        [Required(ErrorMessage ="Es necesario declarar un problema")]
        public string Problema { get; set; }
        [Required(ErrorMessage = "Es necesario declarar una solucion")]
        public string Solucion { get; set; }

        public Casos()
        {
            CasoId = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }
    }
}
