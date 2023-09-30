using System.Data.Common;

namespace Entities.Utilities;

public static class DbConnectionExt
{
    public static void SetIdentityInsert(this DbConnection connection, string tableName, bool status)
    {
        var statusInText = status ? "ON" : "OFF";

        connection.ExecuteNonQuery($"SET IDENTITY_INSERT [dbo].[{tableName}] {statusInText}");
    }

    public static int ExecuteNonQuery(this DbConnection connection, string sql)
    {
        using (var dbCommand = connection.CreateCommand())
        {
            dbCommand.CommandText = sql;
            return dbCommand.ExecuteNonQuery();
        }
    }
}