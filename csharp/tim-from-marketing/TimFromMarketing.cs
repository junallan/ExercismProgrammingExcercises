using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        return $"{(id.HasValue ? $"[{id}] - " : string.Empty)}{name} - {department?.ToUpper() ?? "OWNER"}";
    }
}
