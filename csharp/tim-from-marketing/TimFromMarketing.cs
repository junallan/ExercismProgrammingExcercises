using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var idIdentifier = id.HasValue ? $"[{id}] - " : string.Empty;
        var departementIdentifier = $" - {department?.ToUpper() ?? "OWNER"}";

        return $"{idIdentifier}{name}{departementIdentifier}";
    }
}
