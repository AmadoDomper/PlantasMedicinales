using System.Collections.Generic;
using System.Data;
using Microsoft.SqlServer.Server;

namespace PlantasMedicinales.Entidades
{
    public class ListaModuloCollection
    {
        public static IEnumerable<SqlDataRecord> TSqlDataRecord(List<Modulo> ListaModulo)
        {
            List<SqlDataRecord> listaSqlDataRecord = new List<SqlDataRecord>();

            foreach (Modulo oModulo in ListaModulo)
            {
                SqlDataRecord oSqlDataRecord = new SqlDataRecord(
                    new SqlMetaData[]{ new SqlMetaData("nMenuId", SqlDbType.Int),
                                        new SqlMetaData("nModId", SqlDbType.Int),
                                        new SqlMetaData("nValor", SqlDbType.Bit)
                                    });

                oSqlDataRecord.SetInt32(0, oModulo.nMenuId);
                oSqlDataRecord.SetInt32(1, oModulo.nModId);
                oSqlDataRecord.SetBoolean(2, oModulo.bEstado);
                listaSqlDataRecord.Add(oSqlDataRecord);
            }

            return listaSqlDataRecord;
        }
    }
}
