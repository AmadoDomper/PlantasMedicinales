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
    public class MenuAD
    {
        private Database oDatabase = EnterpriseLibraryContainer.Current.GetInstance<Database>(Conexion.cnsPlaMedicinales);

        public List<Menu> ObtenerMenuFull(int nRolId)
        {
            List<Menu> ListaMenus = new List<Menu>();
            Menu oMenu = null;

            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_SeleccionarMenuFull);
            oDatabase.AddInParameter(oDbCommand, "@nRolId", DbType.Int32, nRolId);

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {
                int inMenuId = oIDataReader.GetOrdinal("nMenuId");
                int inMenuPadre = oIDataReader.GetOrdinal("nMenuPadre");
                int icMenuDesc = oIDataReader.GetOrdinal("cMenuDesc");
                int icMenuIcono = oIDataReader.GetOrdinal("cMenuIcono");
                int inMenuPosicion = oIDataReader.GetOrdinal("nMenuPosicion");
                int icMenuUrl = oIDataReader.GetOrdinal("cMenuUrl");
                int icMenuEstado = oIDataReader.GetOrdinal("cMenuEstado");

                while (oIDataReader.Read())
                {
                    oMenu = new Menu();
                    oMenu.nMenuId = DataUtil.DbValueToDefault<int>(oIDataReader[inMenuId]);
                    oMenu.nMenuPadre = DataUtil.DbValueToDefault<int>(oIDataReader[inMenuPadre]);
                    oMenu.cMenuDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icMenuDesc]);
                    oMenu.cMenuIcono = DataUtil.DbValueToDefault<String>(oIDataReader[icMenuIcono]);
                    oMenu.nMenuposicion = DataUtil.DbValueToDefault<int>(oIDataReader[inMenuPosicion]);
                    oMenu.cMenuUrl = DataUtil.DbValueToDefault<String>(oIDataReader[icMenuUrl]);
                    oMenu.cMenuEstado = DataUtil.DbValueToDefault<String>(oIDataReader[icMenuEstado]);

                    ListaMenus.Add(oMenu);
                }
            }
            return ListaMenus;
        }
    }
}
