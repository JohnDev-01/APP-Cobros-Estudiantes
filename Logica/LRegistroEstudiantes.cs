using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeEstudiantes.Logica
{
    public class LRegistroEstudiantes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Celular { get; set; }
        public string Fecha_Inscripcion { get; set; }
        public string Fecha_Pago { get; set; }
        public int Monto { get; set; }
        public int Habilitado { get; set; }
        public int Dia_De_Pago { get; set; }
        public int YaCobrado { get; set; }
        public string Seccion { get; set; }
        public int MontoReal { get; set; }
        public string Cant_dias { get; set; }
        public int Atraso { get; set; }
        public int Adelanto { get; set; }
    }
}
