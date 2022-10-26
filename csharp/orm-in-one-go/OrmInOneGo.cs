using System;

public class Orm
{
    private Database database;  

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
      try
      {
        this.database.BeginTransaction();
        this.database.Write(data);
        this.database.EndTransaction();
      }
      catch(InvalidOperationException)
      {
        this.database.Dispose();
        throw new InvalidOperationException();
      }
    }

    public bool WriteSafely(string data)
    {
        throw new NotImplementedException($"Please implement the Orm.WriteSafely() method");
    }
}
