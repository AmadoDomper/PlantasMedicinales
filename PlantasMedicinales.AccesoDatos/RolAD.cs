using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.AccesoDatos.Helper;

namespace PlantasMedicinales.AccesoDatos
{
    public class RolAD
    {
        private Database oDatabase = EnterpriseLibraryContainer.Current.GetInstance<Database>(Conexion.cnsPlaMedicinales);

        public List<Rol> ListarRoles()
        {
            List<Rol> ListarRoles = new List<Rol>();

            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_Roles);

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int inRolId = oIDataReader.GetOrdinal("nRolId");
                int icRolDesc = oIDataReader.GetOrdinal("cRolDesc");

                while (oIDataReader.Read())
                {
                    Rol oRol = new Rol();

                    oRol.nRolId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inRolId]);
                    oRol.cRolDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icRolDesc]);

                    ListarRoles.Add(oRol);
                }
            }
            return ListarRoles;
        }

        public bool ValidaSugAprobacion(string cUsuName, int nPermId)
        {
            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_PermisoUsuarioRol);
            oDatabase.AddInParameter(oDbCommand, "@cUsu", DbType.String, cUsuName);
            oDatabase.AddInParameter(oDbCommand, "@nPermId", DbType.Int32, nPermId);
            oDatabase.AddOutParameter(oDbCommand, "@bEstado", DbType.Boolean, 10);

            oDatabase.ExecuteScalar(oDbCommand);
            return Convert.ToBoolean(oDatabase.GetParameterValue(oDbCommand, "@bEstado")); ;
        }


    }
}