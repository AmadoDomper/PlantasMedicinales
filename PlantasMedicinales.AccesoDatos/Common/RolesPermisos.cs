using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasMedicinales.AccesoDatos.Common
{
    public enum RolesPermisos
    {
        #region Usuarios
        Usu_Nuevo_Usuario = 10,
        Usu_Editar_Usuario = 11,
        Usu_Eliminar_Usuario = 12,
        #endregion

        #region Configuración
        Con_Agregar_Rol = 16,
        Con_Editar_Rol = 17,
        Con_Eliminar_Rol = 18,
        #endregion

    }
}
