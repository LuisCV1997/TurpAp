using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
   public class Cliente
    {
        public int Id { get; set; }
        public string RFC { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Control { get; set; }
        public Decimal Salario { get; set; }
        public string Numero_Cliente { get; set; }

        public List<object> Clientes { get; set; }
    }
}
