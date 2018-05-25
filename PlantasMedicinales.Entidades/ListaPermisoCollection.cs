using System.Collections.Generic;
using System.Data;
using Microsoft.SqlServer.Server;

namespace PlantasMedicinales.Entidades
{
    public class ListaPermisoCollection
    {
        public static IEnumerable<SqlDataRecord> TSqlDataRecord(List<Permiso> ListaPermiso)
        {
            List<SqlDataRecord> listaSqlDataRecord = new List<SqlDataRecord>();

            foreach (Permiso oPermiso in ListaPermiso)
            {
                SqlDataRecord oSqlDataRecord = new SqlDataRecord(
                    new SqlMetaData[]{ new SqlMetaData("nModId", SqlDbType.Int),
                                        new SqlMetaData("nPermId", SqlDbType.Int),
                                        new SqlMetaData("nValor", SqlDbType.Bit)
                                    });

                oSqlDataRecord.SetInt32(0, oPermiso.nModId);
                oSqlDataRecord.SetInt32(1, oPermiso.nPermId);
                oSqlDataRecord.SetBoolean(2, oPermiso.bEstado);
                listaSqlDataRecord.Add(oSqlDataRecord);
            }

            return listaSqlDataRecord;
        }
    }
}
