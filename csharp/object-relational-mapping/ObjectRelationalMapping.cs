using System;

public class Orm
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
        this.database.Write(data);
    }

    public void Commit()
    {
        throw new NotImplementedException($"Please implement the Orm.Commit() method");
    }
}
