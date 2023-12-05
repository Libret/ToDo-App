using Microsoft.Data.Sqlite;


namespace ToDo_App.Controllers;

public class SqliteCon
{
    //private static SqliteConnection _con;

    public static SqliteConnection SqliteOpenConnnection()
    {
        SqliteConnection sqliteCon = new SqliteConnection("Data Source=db.sqlite");
        
        try
        {
            sqliteCon.Open();
        }
        catch (Exception ex)
        {

        }
        return sqliteCon;
    }
}