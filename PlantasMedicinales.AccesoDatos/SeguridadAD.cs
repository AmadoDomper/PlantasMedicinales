using PlantasMedicinales.AccesoDatos.Helper;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantasMedicinales.Entidades;


namespace PlantasMedicinales.AccesoDatos
{
    public class SeguridadAD
    {
        private Database oDatabase = EnterpriseLibraryContainer.Current.GetInstance<Database>(Conexion.cnsPlaMedicinales);

        public Usuario ValidaAccesoUsuario(string cUsuario, string cClave)
        {
            Usuario oUsuario = new Usuario();

            try
            {
                using (DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.sp_sel_ValidaAcceso, cUsuario, cClave))
                {
                    using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
                    {
                        int inUsuarioId = oIDataReader.GetOrdinal("nUsuarioId");
                        int icDni = oIDataReader.GetOrdinal("cDni");
                        int icNombre = oIDataReader.GetOrdinal("cNombre");
                        int inRolId = oIDataReader.GetOrdinal("nRolId");
                        int icRolDesc = oIDataReader.GetOrdinal("cRolDesc");
                        int ibEsInterno = oIDataReader.GetOrdinal("Es_Interno");
                        int inEstado = oIDataReader.GetOrdinal("nEstado");


                        while (oIDataReader.Read())
                        {
                            oUsuario.nUsuarioId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inUsuarioId]);
                            oUsuario.cDni = DataUtil.DbValueToDefault<String>(oIDataReader[icDni]);
                            oUsuario.cNombres = DataUtil.DbValueToDefault<String>(oIDataReader[icNombre]);
                            oUsuario.nRolId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inRolId]);
                            oUsuario.cRolDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icRolDesc]);
                            oUsuario.bEsInterno = DataUtil.DbValueToDefault<bool>(oIDataReader[ibEsInterno]);
                            oUsuario.nEstado = DataUtil.DbValueToDefault<Int32>(oIDataReader[inEstado]);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return oUsuario;
        }
    }
}
