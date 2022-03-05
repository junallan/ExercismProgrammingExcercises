using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        this.database.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            this.database.Write(data);
        }
        catch (Exception)
        {
            Dispose();
        }
    }

    public void Commit() => Dispose();

    public void Dispose() => this.database.Dispose();
}
