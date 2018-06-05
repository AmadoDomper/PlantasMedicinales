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
            int resultado = -1;

            try
            {
                using (SqlConnection oSqlConnection = new SqlConnection(Conexion.cnsPlaMedicinalesSQL))
                {
                    SqlCommand oSqlCommand = new SqlCommand();
                    oSqlCommand.CommandText = Procedimiento.stp_ins_upd_PlantaMedicinal;
                    oSqlCommand.CommandType = CommandType.StoredProcedure;
                    oSqlCommand.Connection = oSqlConnection;

                    oSqlCommand.Parameters.Add("@Pli_IdPlinian", SqlDbType.Int).Value = (object)oPlinian.nId ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Codigo", SqlDbType.VarChar, 20).Value = (object)oPlinian.cCodigo ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_NombresComunes", SqlDbType.VarChar, 30).Value = (object)oPlinian.cNombresComunes ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Sinonimia", SqlDbType.VarChar, 350).Value = (object)oPlinian.cSinonimia ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_NombreCientifico", SqlDbType.VarChar, 100).Value = (object)oPlinian.cNombreCientifico ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Familia", SqlDbType.VarChar, 30).Value = (object)oPlinian.cFamilia ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_DescripcionCientifica",SqlDbType.VarChar, 600).Value = (object)oPlinian.cDescripBotanica ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Habitat", SqlDbType.VarChar, 200).Value = (object)oPlinian.cHabitat ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Distribucion", SqlDbType.VarChar,100).Value = (object)oPlinian.cDistribucion ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_CompoQuimica", SqlDbType.VarChar,100).Value = (object)oPlinian.cCompoQuimica ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Toxicidad", SqlDbType.VarChar,100).Value = (object)oPlinian.cToxicidad ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Etnomedicinal", SqlDbType.VarChar,300).Value = (object)oPlinian.cEtnomedicinal ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Manejo", SqlDbType.VarChar,800).Value = (object)oPlinian.cManejo ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Interacciones", SqlDbType.VarChar,20).Value = (object)oPlinian.cInteracciones ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Usos", SqlDbType.VarChar,100).Value = (object)oPlinian.cUsos ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_Vaucher", SqlDbType.VarChar,100).Value = (object)oPlinian.cVaucher ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_ReferenciasBibliograficas", SqlDbType.VarChar,800).Value = (object)oPlinian.cRefeBiblio ?? DBNull.Value;
                    oSqlCommand.Parameters.Add("@Pli_foto", SqlDbType.VarChar,100).Value = (object)oPlinian.cFoto ?? DBNull.Value;

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


        public Plinian CargarDatosPlinian(int nInv)
        {
            try
            {
                Plinian oPli = new Plinian();

                DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_PlantaMedicinal);
                oDatabase.AddInParameter(oDbCommand, "@nPliId", DbType.Int32, (object)nInv ?? DBNull.Value);

                using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
                {

                    int iPli_IdPlinian = oIDataReader.GetOrdinal("Pli_IdPlinian");
                    int iPli_Codigo = oIDataReader.GetOrdinal("Pli_Codigo");
                    int iPli_NombresComunes = oIDataReader.GetOrdinal("Pli_NombresComunes");
                    int iPli_Sinonimia = oIDataReader.GetOrdinal("Pli_Sinonimia");
                    int iPli_NombreCientifico = oIDataReader.GetOrdinal("Pli_NombreCientifico");
                    int iPli_Familia = oIDataReader.GetOrdinal("Pli_Familia");
                    int iPli_DescripcionCientifica = oIDataReader.GetOrdinal("Pli_DescripcionCientifica");
                    int iPli_Habitat = oIDataReader.GetOrdinal("Pli_Habitat");
                    int iPli_Distribucion = oIDataReader.GetOrdinal("Pli_Distribucion");
                    int iPli_CompoQuimica = oIDataReader.GetOrdinal("Pli_CompoQuimica");
                    int iPli_Toxicidad = oIDataReader.GetOrdinal("Pli_Toxicidad");
                    int iPli_Etnomedicinal = oIDataReader.GetOrdinal("Pli_Etnomedicinal");
                    int iPli_Manejo = oIDataReader.GetOrdinal("Pli_Manejo");
                    int iPli_Interacciones = oIDataReader.GetOrdinal("Pli_Interacciones");
                    int iPli_Usos = oIDataReader.GetOrdinal("Pli_Usos");
                    int iPli_Vaucher = oIDataReader.GetOrdinal("Pli_Vaucher");
                    int iPli_ReferenciasBibliograficas = oIDataReader.GetOrdinal("Pli_ReferenciasBibliograficas");
                    int iPli_foto = oIDataReader.GetOrdinal("Pli_foto");
                    int iPli_Estado = oIDataReader.GetOrdinal("Pli_Estado");


                    while (oIDataReader.Read())
                    {


                        oPli.nId = DataUtil.DbValueToDefault<Int32>(oIDataReader[iPli_IdPlinian]);
                        oPli.cCodigo = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Codigo]);
                        oPli.cNombresComunes = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_NombresComunes]);
                        oPli.cSinonimia = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Sinonimia]);
                        oPli.cNombreCientifico = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_NombreCientifico]);
                        oPli.cFamilia = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Familia]);
                        oPli.cDescripBotanica = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_DescripcionCientifica]);
                        oPli.cHabitat = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Habitat]);
                        oPli.cDistribucion = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Distribucion]);
                        oPli.cCompoQuimica = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_CompoQuimica]);
                        oPli.cToxicidad = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Toxicidad]);
                        oPli.cEtnomedicinal = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Etnomedicinal]);
                        oPli.cManejo = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Manejo]);
                        oPli.cInteracciones = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Interacciones]);
                        oPli.cUsos = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Usos]);
                        oPli.cVaucher = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_Vaucher]);
                        oPli.cRefeBiblio = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_ReferenciasBibliograficas]);
                        oPli.cFoto = DataUtil.DbValueToDefault<String>(oIDataReader[iPli_foto]);
                        oPli.nEstado = DataUtil.DbValueToDefault<byte>(oIDataReader[iPli_Estado]);

                    }
                }

                return oPli;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EliminarPlinian(int nPliId)
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

                    oSqlCommand.Parameters.Add("@nPliId", SqlDbType.Int).Value = nPliId;

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