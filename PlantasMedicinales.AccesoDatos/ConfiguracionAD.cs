using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.AccesoDatos.Helper;


namespace PlantasMedicinales.AccesoDatos
{
    public class ConfiguracionAD
    {
        private Database oDatabase = EnterpriseLibraryContainer.Current.GetInstance<Database>(Conexion.cnsPlaMedicinales);

        public List<Menu> ListarMenuRol(int nRolId)
        {
            try
            {
                List<Menu> ListaMenu = new List<Menu>();

                DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_MenuRol);
                oDatabase.AddInParameter(oDbCommand, "@nRolId", DbType.Int32, (object)nRolId ?? DBNull.Value);

                using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
                {
                    int inMenuId = oIDataReader.GetOrdinal("nMenuId");
                    int icMenuDesc = oIDataReader.GetOrdinal("cMenuDesc");
                    int inValor = oIDataReader.GetOrdinal("nValor");

                    while (oIDataReader.Read())
                    {
                        Menu oMenu = new Menu();

                        oMenu.nMenuId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inMenuId]);
                        oMenu.cMenuDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icMenuDesc]);
                        oMenu.bEstado = DataUtil.DbValueToDefault<Boolean>(oIDataReader[inValor]);

                        ListaMenu.Add(oMenu);
                    }
                }

                return ListaMenu;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Modulo> ListarModuloRol(int nRolId)
        {
            try
            {
                List<Modulo> ListaModulo = new List<Modulo>();

                DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_ModuloRol);
                oDatabase.AddInParameter(oDbCommand, "@nRolId", DbType.Int32, (object)nRolId ?? DBNull.Value);

                using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
                {
                    int inMenuId = oIDataReader.GetOrdinal("nMenuId");
                    int inModId = oIDataReader.GetOrdinal("nModId");
                    int icMenuDesc = oIDataReader.GetOrdinal("cModDesc");
                    int inValor = oIDataReader.GetOrdinal("nValor");

                    while (oIDataReader.Read())
                    {
                        Modulo oModulo = new Modulo();

                        oModulo.nMenuId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inMenuId]);
                        oModulo.nModId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inModId]);
                        oModulo.cModDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icMenuDesc]);
                        oModulo.bEstado = DataUtil.DbValueToDefault<Boolean>(oIDataReader[inValor]);

                        ListaModulo.Add(oModulo);
                    }
                }

                return ListaModulo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Permiso> ListarPermisoRol(int nRolId)
        {
            try
            {
                List<Permiso> ListaPermiso = new List<Permiso>();

                DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_PermisoRol);
                oDatabase.AddInParameter(oDbCommand, "@nRolId", DbType.Int32, (object)nRolId ?? DBNull.Value);

                using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
                {
                    int inModId = oIDataReader.GetOrdinal("nModId");
                    int inPermId = oIDataReader.GetOrdinal("nPermId");
                    int icPermDesc = oIDataReader.GetOrdinal("cPermDesc");
                    int inValor = oIDataReader.GetOrdinal("nValor");

                    while (oIDataReader.Read())
                    {
                        Permiso oPermiso = new Permiso();

                        oPermiso.nModId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inModId]);
                        oPermiso.nPermId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inPermId]);
                        oPermiso.cPermDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icPermDesc]);
                        oPermiso.bEstado = DataUtil.DbValueToDefault<Boolean>(oIDataReader[inValor]);

                        ListaPermiso.Add(oPermiso);
                    }
                }

                return ListaPermiso;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int RegistrarActualizarRolPermisos(int nRolId, string cRolDesc, List<Menu> ListMenu, List<Modulo> ListModulo, List<Permiso> ListaPermiso)
        {
            int resultado = -1;

            try
            {
                using (SqlConnection oSqlConnection = new SqlConnection(Conexion.cnsPlaMedicinalesSQL))
                {
                    SqlCommand oSqlCommand = new SqlCommand();
                    oSqlCommand.CommandText = Procedimiento.stp_ins_upd_RolPermisos;
                    oSqlCommand.CommandType = CommandType.StoredProcedure;
                    oSqlCommand.Connection = oSqlConnection;

                    oSqlCommand.Parameters.Add("@nRolId", SqlDbType.Int).Value = (object)nRolId ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@cRolDesc", SqlDbType.VarChar, 100).Value = (object)cRolDesc ?? DBNull.Value;

                    oSqlCommand.Parameters.Add("@T_MenuRol", SqlDbType.Structured).Value = ListaMenuCollection.TSqlDataRecord(ListMenu.ToList());
                    oSqlCommand.Parameters.Add("@T_ModuloRol", SqlDbType.Structured).Value = ListaModuloCollection.TSqlDataRecord(ListModulo.ToList());
                    oSqlCommand.Parameters.Add("@T_PermisoRol", SqlDbType.Structured).Value = ListaPermisoCollection.TSqlDataRecord(ListaPermiso.ToList());
                    oSqlConnection.Open();

                    using (IDataReader oIDataReader = oSqlCommand.ExecuteReader())
                    {
                        int iResultado = oIDataReader.GetOrdinal("Resultado");

                        while (oIDataReader.Read())
                        {
                            resultado = DataUtil.DbValueToDefault<int>(oIDataReader[iResultado]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                resultado = -1;
            }
            return resultado;
        }


        public int EliminarRol(int nRolId)
        {
            int resultado = -1;

            try
            {
                using (SqlConnection oSqlConnection = new SqlConnection(Conexion.cnsPlaMedicinalesSQL))
                {
                    SqlCommand oSqlCommand = new SqlCommand();
                    oSqlCommand.CommandText = Procedimiento.stp_del_EliminarRol;
                    oSqlCommand.CommandType = CommandType.StoredProcedure;
                    oSqlCommand.Connection = oSqlConnection;

                    oSqlCommand.Parameters.Add("@nRolId", SqlDbType.Int).Value = (object)nRolId ?? DBNull.Value;

                    oSqlConnection.Open();

                    using (IDataReader oIDataReader = oSqlCommand.ExecuteReader())
                    {
                        int iResultado = oIDataReader.GetOrdinal("Resultado");

                        while (oIDataReader.Read())
                        {
                            resultado = DataUtil.DbValueToDefault<int>(oIDataReader[iResultado]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                resultado = -1;
            }
            return resultado;
        }
    }
}