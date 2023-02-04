using System.Collections.Generic;

public class Authenticator
{
    private class EyeColor
    {
        private const string Blue = "blue";
        private const string Green = "green";
        private const string Brown = "brown";
        private const string Hazel = "hazel";
        private const string Brey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.admin = admin.Clone();
    }

    private Identity admin;

    private readonly IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin
    {
        get { return admin; }
        set { admin = value; }
    }

    public IDictionary<string, Identity> GetDevelopers()
    {
        return developers.Clone();;
    }
}

public struct Identity
{
    public string Email { get; set; }

    public string EyeColor { get; set; }
}
