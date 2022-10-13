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

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures.GetHashCode());
}

public class Authenticator
{
    private readonly Identity Admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    private HashSet<int> _registeredApplicants = new HashSet<int>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.EyeColor.Equals(faceB.EyeColor) && faceA.PhiltrumWidth.Equals(faceB.PhiltrumWidth);

    public bool IsAdmin(Identity identity) => identity.GetHashCode() == Admin.GetHashCode();

    public bool Register(Identity identity)
    {
        if(IsRegistered(identity)) return false;

        _registeredApplicants.Add(identity.GetHashCode());

        return true;
    }

    public bool IsRegistered(Identity identity) => _registeredApplicants.Contains(identity.GetHashCode());

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;
}