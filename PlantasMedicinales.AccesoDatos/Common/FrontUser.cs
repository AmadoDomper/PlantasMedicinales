using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using PlantasMedicinales.Entidades;

namespace PlantasMedicinales.AccesoDatos.Common
{
    public class FrontUser
    {
        public static bool TienePermiso(RolesPermisos valor)
        {
            return new RolAD().ValidaSugAprobacion(((Usuario)HttpContext.Current.Session["Datos"]).cDni, (int)valor);
        }
    }
}
