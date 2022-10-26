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
      using var database = this.database;

      try
      {
        database.BeginTransaction();
        database.Write(data);
        database.EndTransaction();
      }
      catch(InvalidOperationException)
      {
        database.Dispose();
        
        throw new InvalidOperationException();
      }
    }

    public bool WriteSafely(string data)
    {
      using var database = this.database;  

      try
      {
        database.BeginTransaction();
        database.Write(data);
        database.EndTransaction();
      }
      catch(InvalidOperationException)
      {
        database.Dispose();

        return false;
      }

      return true;
    }
}
