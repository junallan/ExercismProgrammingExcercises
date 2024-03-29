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
    Read = 0b_0000_0001,
    Write = 0b_0000_0010,
    Delete = 0b_0000_0100,
    All = Read | Write | Delete,
    None = 0b_0000_0000
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,
            _ => Permission.None
        };
    }

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke) => current & ~revoke;

    private static bool IsPermissionToBeRemoved(Permission current, Permission revoke, Permission permissionToRemove) 
                                    => Check(revoke, permissionToRemove) && Check(current, permissionToRemove);

    public static bool Check(Permission current, Permission check) => current.HasFlag(check);
}
