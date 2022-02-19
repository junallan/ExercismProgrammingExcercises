using System;

public enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
public enum Permission
{
    Read = 0b00000001,
    Write = 0b00000010,
    Delete = 0b00000100,
    All = 0b00000111,
    None = 0b00000000
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
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        if(revoke == Permission.None) return current;
        if(revoke == Permission.All) return Permission.None;

        Permission newPermission = current;

        if(((revoke & Permission.Read) == Permission.Read) && ((current & Permission.Read) == Permission.Read)) newPermission = newPermission - (byte)Permission.Read;
        if(((revoke & Permission.Write) == Permission.Write) && ((current & Permission.Write) == Permission.Write)) newPermission = newPermission - (byte)Permission.Write;
        if(((revoke & Permission.Delete) == Permission.Delete) && ((current & Permission.Delete) == Permission.Delete)) newPermission = newPermission - (byte)Permission.Delete;

        return newPermission;
    }

    public static bool Check(Permission current, Permission check)
    {
        throw new NotImplementedException("Please implement the (static) Permissions.Check() method");
    }
}
