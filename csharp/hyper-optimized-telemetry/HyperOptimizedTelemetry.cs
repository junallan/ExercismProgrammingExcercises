using System;
using System.Collections.Generic;

public static class TelemetryBuffer
{
    private const int BitsInByte = 256;
    private const int ShortByteCount = 2;
    private const int IntByteCount = 4;
    private const int LongByteCount = 8;

    public static byte[] ToBuffer(long reading)
    {
        byte[] result = new byte[9];

        if (UInt32.MaxValue < reading && reading <= Int64.MaxValue) result[0] = BitsInByte - LongByteCount;
        else if(Int32.MaxValue < reading) result[0] = IntByteCount;
        else if(UInt16.MaxValue < reading) result[0] = BitsInByte - IntByteCount;
        else if(Int16.MaxValue < reading) result[0] = ShortByteCount;
        else if(Int16.MinValue <= reading)
        {
            result[0] = BitsInByte - ShortByteCount;
            var payload = BitConverter.GetBytes((short) reading);
            payload.CopyTo(result, 1);
        }
        else if(Int32.MinValue <= reading)
        {
            result[0] = BitsInByte - IntByteCount;
            var payload = BitConverter.GetBytes((int)reading);
            payload.CopyTo(result, 1);
        }
        else
        {
            result[0] = BitsInByte - LongByteCount;
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
        var allowedPrefixes = new List<int>{ -LongByteCount, -IntByteCount, -ShortByteCount, ShortByteCount, IntByteCount, 0 };
        
        if (!allowedPrefixes.Contains((int)buffer[0]))
        {
            return 0;
        }

        return 1;
    }
}
