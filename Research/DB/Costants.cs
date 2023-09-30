using SQLite;

namespace Research.DB;

public static class Costants
{
    public const string DbName = "ApplicationDatabase.db3";

    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite
                                         | SQLiteOpenFlags.Create
                                         | SQLiteOpenFlags.SharedCache;

    public static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);
}