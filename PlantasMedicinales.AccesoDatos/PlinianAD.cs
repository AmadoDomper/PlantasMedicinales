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
    public class PlinianAD
    {
        private Database oDatabase = EnterpriseLibraryContainer.Current.GetInstance<Database>(Conexion.cnsPlaMedicinales);

        public ListaPaginada ListarPlantasPag(int nPage = 1, int nSize = 10, string cValor = null)
        {
            ListaPaginada ListaUsuPag = new ListaPaginada();

            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_ListarPlantasMedicinales);
            oDatabase.AddInParameter(oDbCommand, "@cValor", DbType.String, (object)cValor ?? DBNull.Value);
            oDatabase.AddInParameter(oDbCommand, "@nPageN", DbType.Int32, nPage);
            oDatabase.AddInParameter(oDbCommand, "@nPageSize", DbType.Int32, nSize);
            oDatabase.AddOutParameter(oDbCommand, "@nRows", DbType.Int32, 10);
            oDatabase.AddOutParameter(oDbCommand, "@nPageTotal", DbType.Int32, 10);

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {

                int iPli_IdPlinian		      = oIDataReader.GetOrdinal("Pli_IdPlinian");		
                int iPli_Codigo			      = oIDataReader.GetOrdinal("Pli_Codigo");
                int iPli_NombresComunes	      = oIDataReader.GetOrdinal("Pli_NombresComunes");
                int iPli_NombreCientifico     = oIDataReader.GetOrdinal("Pli_NombreCientifico");
                int iPli_Familia			  = oIDataReader.GetOrdinal("Pli_Familia");
                int iPli_Estado               = oIDataReader.GetOrdinal("Pli_Estado");	

                while (oIDataReader.Read())
                {
                    Plinian oPlinian = new Plinian();

                    oPlinian.nId                    = DataUtil.DbValueToDefault<Int32>(oIDataReader[iPli_IdPlinian]);
                    oPlinian.cCodigo                = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Codigo]);
                    oPlinian.cNombresComunes        = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_NombresComunes]);
                    oPlinian.cNombreCientifico      = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_NombreCientifico]);
                    oPlinian.cFamilia               = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Familia]);
                    oPlinian.nEstado                = DataUtil.DbValueToDefault<Byte>(oIDataReader[iPli_Estado]);

                    ListaUsuPag.oLista.Add(oPlinian);
                }
            }

            ListaUsuPag.nPage = nPage;
            ListaUsuPag.nPageSize = nSize;
            ListaUsuPag.nRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@nRows"));
            ListaUsuPag.nPageTotal = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@nPageTotal"));

            return ListaUsuPag;
        }

        public int RegistrarModificarPlinian(Plinian oPlinian)
        {
            int resultado = -2;

            try
            {
                using (SqlConnection oSqlConnection = new SqlConnection(Conexion.cnsPlaMedicinalesSQL))
                {
                    SqlCommand oSqlCommand = new SqlCommand();
                    oSqlCommand.CommandText = Procedimiento.stp_ins_upd_PlantaMedicinal;
                    oSqlCommand.CommandType = CommandType.StoredProcedure;
                    oSqlCommand.Connection = oSqlConnection;

                    //oSqlCommand.Parameters.Add("@nUsuId", SqlDbType.Int).Value = (object)oUsuario.nUsuarioId ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cNombre", SqlDbType.VarChar, 150).Value = (object)oUsuario.cNombres ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cApellidoPaterno", SqlDbType.VarChar, 150).Value = (object)oUsuario.cApellidoPa ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cApellidoMaterno", SqlDbType.VarChar, 150).Value = (object)oUsuario.cApellidoMa ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cInstitucion", SqlDbType.VarChar, 200).Value = (object)oUsuario.cInstitucion ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cEmail", SqlDbType.VarChar, 150).Value = (object)oUsuario.cEmail ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cDni", SqlDbType.VarChar, 10).Value = (object)oUsuario.cDni ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@cContrasena", SqlDbType.VarChar, 50).Value = (object)oUsuario.cContrasena ?? DBNull.Value;
                    //oSqlCommand.Parameters.Add("@nRolId", SqlDbType.Int).Value = (object)oUsuario.nRolId ?? DBNull.Value;

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
                resultado = -2;
            }
            return resultado;
        }


        public Usuario CargarDatosPlinian(int nUsuId)
        {
            try
            {
                Usuario oUsuario = new Usuario();

                DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_PlantaMedicinal);
                oDatabase.AddInParameter(oDbCommand, "@nUsuarioId", DbType.Int32, (object)nUsuId ?? DBNull.Value);

                using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
                {
                    int inUsuarioId = oIDataReader.GetOrdinal("nUsuarioId");
                    int icNombres = oIDataReader.GetOrdinal("cNombres");
                    int icApellidoPaterno = oIDataReader.GetOrdinal("cApellidoPaterno");
                    int icApellidoMaterno = oIDataReader.GetOrdinal("cApellidoMaterno");
                    int icInstitucion = oIDataReader.GetOrdinal("cInstitucion");
                    int icEmail = oIDataReader.GetOrdinal("cEmail");
                    int icDni = oIDataReader.GetOrdinal("cDni");
                    int inRolId = oIDataReader.GetOrdinal("nRolId");
                    int icRolDesc = oIDataReader.GetOrdinal("cRolDesc");

                    while (oIDataReader.Read())
                    {
                        oUsuario.nUsuarioId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inUsuarioId]);
                        oUsuario.cNombres = DataUtil.DbValueToDefault<String>(oIDataReader[icNombres]);
                        oUsuario.cApellidoPa = DataUtil.DbValueToDefault<String>(oIDataReader[icApellidoPaterno]);
                        oUsuario.cApellidoMa = DataUtil.DbValueToDefault<String>(oIDataReader[icApellidoMaterno]);
                        oUsuario.cInstitucion = DataUtil.DbValueToDefault<String>(oIDataReader[icInstitucion]);
                        oUsuario.cEmail = DataUtil.DbValueToDefault<String>(oIDataReader[icEmail]);
                        oUsuario.cDni = DataUtil.DbValueToDefault<String>(oIDataReader[icDni]);
                        oUsuario.nRolId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inRolId]);
                        oUsuario.cRolDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icRolDesc]);
                    }
                }

                return oUsuario;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EliminarPlinian(int nUsuarioId)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection oSqlConnection = new SqlConnection(Conexion.cnsPlaMedicinalesSQL))
                {
                    SqlCommand oSqlCommand = new SqlCommand();
                    oSqlCommand.CommandText = Procedimiento.stp_del_PlantaMedicinal;
                    oSqlCommand.CommandType = CommandType.StoredProcedure;
                    oSqlCommand.Connection = oSqlConnection;

                    oSqlCommand.Parameters.Add("@nUsuarioId", SqlDbType.Int).Value = nUsuarioId;

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