using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Citas
{
    public class Cliente
    {
        [Key]
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; } 

        public int Citaid { get; set; }
        public Agendar_citas? Cita { get; set; }
    }
}
