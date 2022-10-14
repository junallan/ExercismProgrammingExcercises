using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);

    public override bool Equals(object obj)
    {
        return Equals(obj as FacialFeatures);
    }

    public bool Equals(FacialFeatures other)
    {
        return other != null &&
                    EyeColor == other.EyeColor &&
                    PhiltrumWidth == other.PhiltrumWidth;
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);

    public override bool Equals(object obj)
    {
        return Equals(obj as Identity);
    }

    public bool Equals(Identity other)
    {
        return other != null && 
                        other.FacialFeatures != null &&
                        Email == other.Email &&
                        FacialFeatures.EyeColor == other.FacialFeatures.EyeColor &&
                        FacialFeatures.PhiltrumWidth == other.FacialFeatures.PhiltrumWidth;
    }
}

public class Authenticator
{
    private readonly Identity Admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    private HashSet<Identity> _registeredApplicants = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(Admin);

    public bool Register(Identity identity)
    {
        if(IsRegistered(identity)) return false;

        _registeredApplicants.Add(identity);

        return true;
    }

    public bool IsRegistered(Identity identity) => _registeredApplicants.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;
}