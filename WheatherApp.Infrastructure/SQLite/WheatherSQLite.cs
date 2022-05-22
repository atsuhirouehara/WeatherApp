using System;
using System.Data.SQLite;
using WheatherApp.Domain.Entities;
using WheatherApp.Domain.Repositories;

namespace WheatherApp.Infrastructure.SQLite
{
    public class WheatherSQLite : IWheatherRepository
    {
        public WheatherEntity GetLatest(int areaId)
        {
            // AreaIdで検索し、該当レコードをDataDate順に並び替えて、トップの1件目を取得する
            string sql = @"select DataDate,
                                  Condition,
                                  Temperature 
                                  from Weather 
                                  where AreaId = @AreaId order by DataDate desc LIMIT 1";

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        return new WheatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                    }
                }
            }

            return null;
        }
        
    }
}
