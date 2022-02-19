using System;

public enum AccountType
{
    Guest,
    User,
    Moderator
}

public enum Permission
{
    Read,
    Write,
    Delete,
    All,
    None
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        if(accountType == AccountType.Guest) return Permission.Read;
        if(accountType == AccountType.User) return Permission.Read | Permission.Write;
        if(accountType == AccountType.Moderator) return Permission.All;
        return Permission.None;
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        throw new NotImplementedException("Please implement the (static) Permissions.Grant() method");
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        throw new NotImplementedException("Please implement the (static) Permissions.Revoke() method");
    }

    public static bool Check(Permission current, Permission check)
    {
        throw new NotImplementedException("Please implement the (static) Permissions.Check() method");
    }
}
