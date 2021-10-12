using System;

static class Badge
{
    private static string GetIdentifierLabel(int? id) => id.HasValue ? $"[{id}] - " : string.Empty;
    private static string GetDepartementLabel(string? department) => department?.ToUpper() ?? "OWNER";
    public static string Print(int? id, string name, string? department) => $"{GetIdentifierLabel(id)}{name} - {GetDepartementLabel(department)}";
}
