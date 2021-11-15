using System;
using System.Collections.Generic;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] result = new byte[9];

        if (UInt32.MaxValue < reading && reading <= Int64.MaxValue) result[0] = 256 - 8;
        else if(Int32.MaxValue < reading) result[0] = 4;
        else if(UInt16.MaxValue < reading) result[0] = 256 - 4;
        else if(Int16.MaxValue < reading) result[0] =2;
        else if(Int16.MinValue <= reading)
        {
            result[0] = 256 - 2;
            var payload = BitConverter.GetBytes((short) reading);
            payload.CopyTo(result, 1);
        }
        else if(Int32.MinValue <= reading)
        {
            result[0] = 256 - 4;
            var payload = BitConverter.GetBytes((int)reading);
            payload.CopyTo(result, 1);
        }
        else
        {
            result[0] = 256 - 8;
            var payload = BitConverter.GetBytes((long)reading);
            payload.CopyTo(result, 1);
        }
   
        if(reading >= 0)
        {
            var payload = BitConverter.GetBytes(reading);
            payload.CopyTo(result, 1);
        }
     
        
        return result;
    }

    public static long FromBuffer(byte[] buffer)
    {
        throw new NotImplementedException("Please implement the static TelemetryBuffer.FromBuffer() method");
    }
}
