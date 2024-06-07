using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeEstudiantes.Logica
{
    public class LPEstuadiantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Inscripcion { get; set; }
        public string Fecha_Pago { get; set; }
        public string Tipo { get; set; }
        public int Monto_Aplicado { get; set; }
        public int Atraso { get; set; }
        public int Habilitado { get; set; }
        public int Adelanto { get; set; }
        public int Monto_A_Pagar { get; set; }
        public string Cant { get; set; }

    }
}
