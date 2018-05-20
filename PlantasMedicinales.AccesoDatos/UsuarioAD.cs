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
    public class UsuarioAD
    {
        private Database oDatabase = EnterpriseLibraryContainer.Current.GetInstance<Database>(Conexion.cnsPlaMedicinales);

        public ListaPaginada ListarUsuariosPag(int nPage = 1, int nSize = 10, int nUsuId = -1, string cUsuDni = "", string cUsuName = "")
        {
            ListaPaginada ListaUsuPag = new ListaPaginada();

            DbCommand oDbCommand = oDatabase.GetStoredProcCommand(Procedimiento.stp_sel_ListarUsuarios);
            oDatabase.AddInParameter(oDbCommand, "@nUsuId", DbType.Int32, (object)nUsuId ?? DBNull.Value);
            oDatabase.AddInParameter(oDbCommand, "@cUsuDni", DbType.String, (object)cUsuDni ?? DBNull.Value);
            oDatabase.AddInParameter(oDbCommand, "@cUsuName", DbType.String, (object)cUsuName ?? DBNull.Value);
            oDatabase.AddInParameter(oDbCommand, "@nPageN", DbType.Int32, nPage);
            oDatabase.AddInParameter(oDbCommand, "@nPageSize", DbType.Int32, nSize);
            oDatabase.AddOutParameter(oDbCommand, "@nRows", DbType.Int32, 10);
            oDatabase.AddOutParameter(oDbCommand, "@nPageTotal", DbType.Int32, 10);

            using (IDataReader oIDataReader = oDatabase.ExecuteReader(oDbCommand))
            {

                int inUsuId = oIDataReader.GetOrdinal("nUsuarioId");
                int icDni = oIDataReader.GetOrdinal("cDni");
                int icNombres = oIDataReader.GetOrdinal("cNombres");
                int icRolDesc = oIDataReader.GetOrdinal("cRolDesc");
                int icTipoUsuario = oIDataReader.GetOrdinal("cTipoUsuario");
                int icEmail = oIDataReader.GetOrdinal("cEmail");

                while (oIDataReader.Read())
                {
                    Usuario oUsuario = new Usuario();

                    oUsuario.nUsuarioId = DataUtil.DbValueToDefault<Int32>(oIDataReader[inUsuId]);
                    oUsuario.cDni = DataUtil.DbValueToDefault<String>(oIDataReader[icDni]);
                    oUsuario.cNombres = DataUtil.DbValueToDefault<String>(oIDataReader[icNombres]);
                    oUsuario.cRolDesc = DataUtil.DbValueToDefault<String>(oIDataReader[icRolDesc]);
                    oUsuario.cTipoUsuario = DataUtil.DbValueToDefault<String>(oIDataReader[icTipoUsuario]);
                    oUsuario.cEmail = DataUtil.DbValueToDefault<String>(oIDataReader[icEmail]);                 

                    ListaUsuPag.oLista.Add(oUsuario);
                }
            }

            ListaUsuPag.nPage = nPage;
            ListaUsuPag.nPageSize = nSize;
            ListaUsuPag.nRows = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@nRows"));
            ListaUsuPag.nPageTotal = Convert.ToInt32(oDatabase.GetParameterValue(oDbCommand, "@nPageTotal"));

            return ListaUsuPag;
        }

        //public int RegistrarModificarUsuario(Usuario oUsu)
        //{
        //    var conexion = new ConexionPosgreSQL();
        //    var resultado = -1;

        //    using (var db = conexion.AbreConexion())
        //    {
        //        try
        //        {
        //            using (NpgsqlCommand cmd = ConexionPosgreSQL.Procedimiento(Procedimiento.usp_Crear_o_ModificarUsuario))
        //            {
        //                cmd.Parameters.AddWithValue("_usu_nusuarioid", oUsu.nUsuarioId);
        //                cmd.Parameters.AddWithValue("_usu_cdni", oUsu.cDni);
        //                cmd.Parameters.AddWithValue("_usu_ccontrasena", oUsu.cContrasena);
        //                cmd.Parameters.AddWithValue("_usu_cnombres", oUsu.cNombres.ToUpper());
        //                cmd.Parameters.AddWithValue("_usu_capellido_paterno", oUsu.cApellidoPa.ToUpper());
        //                cmd.Parameters.AddWithValue("_usu_capellido_materno", oUsu.cApellidoMa.ToUpper());
        //                cmd.Parameters.AddWithValue("_usu_cinstitucion", oUsu.cInstitucion);
        //                cmd.Parameters.AddWithValue("_usu_cpais", oUsu.cPais);
        //                cmd.Parameters.AddWithValue("_usu_cciudad", oUsu.cCiudad);
        //                cmd.Parameters.AddWithValue("_usu_cemail", oUsu.cEmail);
        //                cmd.Parameters.AddWithValue("_usu_dfechanacimiento", String.Format(oUsu.cFechaNacimiento, "yyyy-mm-dd"));
        //                cmd.Parameters.AddWithValue("_rol_nrolid", oUsu.nRolId);
        //                cmd.Parameters.AddWithValue("_usu_es_interno", oUsu.bEsInterno);
        //                var reader = cmd.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    resultado = Int32.Parse(reader[0].ToString());
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    return resultado;
        //}

        //public Usuario CargarDatosUsuario(int nUsuId)
        //{
        //    var conexion = new ConexionPosgreSQL();
        //    var oUsu = new Usuario();

        //    using (var db = conexion.AbreConexion())
        //    {
        //        try
        //        {
        //            using (NpgsqlCommand cmd = ConexionPosgreSQL.Procedimiento(Procedimiento.usp_CargarDatosUsuario))
        //            {
        //                cmd.Parameters.AddWithValue("_nUsuId", nUsuId);
        //                var reader = cmd.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    oUsu.nUsuarioId = (int)reader["usu_nusuarioid"];
        //                    oUsu.cNombres = (string)reader["usu_cnombres"];
        //                    oUsu.cApellidoPa = (string)reader["usu_capellido_paterno"];
        //                    oUsu.cApellidoMa = (string)reader["usu_capellido_materno"];
        //                    oUsu.cInstitucion = (string)reader["usu_cinstitucion"];
        //                    oUsu.cEmail = (string)reader["usu_cemail"];
        //                    oUsu.cFechaNacimiento = (string)reader["usu_dfechanacimiento"];
        //                    oUsu.cDni = (string)reader["usu_cdni"];
        //                    oUsu.cPais = (string)reader["usu_cpais"];
        //                    oUsu.cCiudad = (string)reader["usu_cciudad"];
        //                    oUsu.nRolId = (int)reader["rol_nrolId"];
        //                    oUsu.cRolDesc = (string)reader["croldesc"];
        //                    oUsu.cContrasena = (string)reader["usu_ccontrasena"];
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    return oUsu;
        //}

        //public void ObtenerPaginadoUsuario(ref ListaPaginada oLista, int nSize = 10, int nUsuId = -1, string cUsuDni = null, string cUsuName = null)
        //{
        //    var conexion = new ConexionPosgreSQL();

        //    using (var db = conexion.AbreConexion())
        //    {
        //        try
        //        {
        //            using (NpgsqlCommand cmd = ConexionPosgreSQL.Procedimiento(Procedimiento.usp_ObtenerPaginadoUsuarios))
        //            {
        //                cmd.Parameters.AddWithValue("_usu_nUsuarioId", nUsuId);
        //                cmd.Parameters.AddWithValue("_usu_cdni", cUsuDni);
        //                cmd.Parameters.AddWithValue("_cNombre", cUsuName);
        //                cmd.Parameters.AddWithValue("_nSize", nSize);

        //                NpgsqlDataReader reader = cmd.ExecuteReader();

        //                while (reader.Read())
        //                {
        //                    oLista.nRows = Int32.Parse(reader[0].ToString());
        //                    oLista.nPageTotal = Int32.Parse(reader[1].ToString());
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}

    }
}
