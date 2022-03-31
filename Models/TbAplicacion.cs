using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trabajo_final_API.Models
{
    public partial class TbAplicacion
    {


        public int Id_Aplicacion { get; set; }
        public int Id_SquadApp { get; set; }

        public string Cod_Aplicacion { get; set; }
        public string Nombre { get; set; }
        public string Cod_Owner { get; set; }
        public string Binding_Block { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string Usuario_Ingreso { get; set; }
        public string Usuario_Actualiza { get; set; }
        public int Flag_Activo { get; set; }

        public virtual TbAplicacion IdTAplicacionNavigation { get; set; }

    }
}
