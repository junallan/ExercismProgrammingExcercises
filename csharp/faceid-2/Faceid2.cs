using System;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
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

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures.EyeColor, FacialFeatures.PhiltrumWidth);
    }
}

public class Authenticator
{
    private readonly Identity Admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.EyeColor.Equals(faceB.EyeColor) && faceA.PhiltrumWidth.Equals(faceB.PhiltrumWidth);

    public bool IsAdmin(Identity identity) => identity.GetHashCode() == Admin.GetHashCode();

    public bool Register(Identity identity)
    {
        throw new NotImplementedException("Please implement the Authenticator.Register() method");
    }

    public bool IsRegistered(Identity identity)
    {
        throw new NotImplementedException("Please implement the Authenticator.IsRegistered() method");
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        throw new NotImplementedException("Please implement the Authenticator.AreSameObject() method");
    }
}
