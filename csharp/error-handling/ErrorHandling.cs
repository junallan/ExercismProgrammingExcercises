using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception();
    public static int? HandleErrorByReturningNullableType(string input) => Int32.TryParse(input, out int result) ? result : null;
    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        result = 0;
        
        var isSuccess = Int32.TryParse(input, out result);
       
        return isSuccess;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
