using System;
using System.Collections.Generic;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        List<byte> result = new List<byte>();
        //How to determine size of type and if signed/unsigned?
        result.Add(256 - 8); 
        
        var payload = BitConverter.GetBytes(reading);
        result.AddRange(payload);

        return result.ToArray();
    }

    public static long FromBuffer(byte[] buffer)
    {
        throw new NotImplementedException("Please implement the static TelemetryBuffer.FromBuffer() method");
    }
}