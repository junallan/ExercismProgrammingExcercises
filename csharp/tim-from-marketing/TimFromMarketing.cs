using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idIdentifier = id.HasValue ? $"[{id}] - " : string.Empty;
        string departementIdentifier = $" - {department?.ToUpper() ?? "OWNER"}";

        return $"{idIdentifier}{name}{departementIdentifier}";
    }
}
