using System;
using System.Collections.Generic;
using System.Linq;

public static class TelemetryBuffer
{
    private const int BitsInByte = 256;
    private const int ShortByteCount = 2;
    private const int IntByteCount = 4;
    private const int LongByteCount = 8;

    private static byte ShortSignedPrefixByte = BitsInByte - ShortByteCount;
    private static byte IntSignedPrefixByte = BitsInByte - IntByteCount;
    private static byte LongSignedPrefixByte = BitsInByte - LongByteCount;

    public static byte[] ToBuffer(long reading)
    {
        byte[] result = new byte[9];

        if (UInt32.MaxValue < reading && reading <= Int64.MaxValue) result[0] = LongSignedPrefixByte;
        else if(Int32.MaxValue < reading) result[0] = IntByteCount;
        else if(UInt16.MaxValue < reading) result[0] = IntSignedPrefixByte;
        else if(Int16.MaxValue < reading) result[0] = ShortByteCount;
        else if(Int16.MinValue <= reading)
        {
            result[0] = ShortSignedPrefixByte;
            var payload = BitConverter.GetBytes((short) reading);
            payload.CopyTo(result, 1);
        }
        else if(Int32.MinValue <= reading)
        {
            result[0] = IntSignedPrefixByte;
            var payload = BitConverter.GetBytes((int)reading);
            payload.CopyTo(result, 1);
        }
        else
        {
            result[0] = LongSignedPrefixByte;
            var payload = BitConverter.GetBytes((long)reading);
            payload.CopyTo(result, 1);
        }

        if (reading >= 0)
        {
            var payload = BitConverter.GetBytes(reading);
            payload.CopyTo(result, 1);
        }
     
        
        return result;
    }
   

    public static long FromBuffer(byte[] buffer)
    {
        var allowedPrefixes = new List<byte> { LongSignedPrefixByte, IntSignedPrefixByte, ShortSignedPrefixByte, ShortByteCount, IntByteCount, 0 };
       
        if (!allowedPrefixes.Contains(buffer[0])) return 0;
        else if (ShortSignedPrefixByte == buffer[0]) return BitConverter.ToInt16(buffer, 1);
        else if (IntSignedPrefixByte == buffer[0]) return BitConverter.ToInt32(buffer, 1);
        else return BitConverter.ToInt64(buffer, 1);
    }

  

  
}
