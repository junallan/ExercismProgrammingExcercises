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

    public void Commit()
    {
        try
        {
            this.database.EndTransaction();
        }
        catch(Exception)
        {
            Dispose();
        }

    }

    public void Dispose()
    {
        Orm orm = this;
        orm.database.Dispose();
    }
}
