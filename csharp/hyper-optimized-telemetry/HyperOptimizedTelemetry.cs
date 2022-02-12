using System;
using System.Collections.Generic;
using System.Linq;

public static class TelemetryBuffer
{
    private const int BitsInByte = 256;
    private const int ShortByteCount = 2;
    private const int IntByteCount = 4;
    private const int LongByteCount = 8;

    private const byte ShortSignedPrefixByte = BitsInByte - ShortByteCount;
    private const byte IntSignedPrefixByte = BitsInByte - IntByteCount;
    private const byte LongSignedPrefixByte = BitsInByte - LongByteCount;

    public static byte[] ToBuffer(long reading)
    {
        byte[] result = new byte[9];

        result[0] = reading switch
        {
            long bufferContent when UInt32.MaxValue < bufferContent && bufferContent <= Int64.MaxValue => LongSignedPrefixByte,
            > Int32.MaxValue => IntByteCount,
            > UInt16.MaxValue => IntSignedPrefixByte,
            >= 0 => ShortByteCount,
            >= Int16.MinValue => ShortSignedPrefixByte,
            >= Int32.MinValue => IntSignedPrefixByte,
            _ => LongSignedPrefixByte
        };

        var payload = reading switch
        {
            >= 0 => BitConverter.GetBytes(reading),
            >= Int16.MinValue => BitConverter.GetBytes((short)reading),
            >= Int32.MinValue => BitConverter.GetBytes((int)reading),
            _ => BitConverter.GetBytes((long)reading)
        };

        payload.CopyTo(result, 1);

        return result;
    }
   

    public static long FromBuffer(byte[] buffer)
    {
        var allowedPrefixes = new List<byte> { LongSignedPrefixByte, IntSignedPrefixByte, ShortSignedPrefixByte, ShortByteCount, IntByteCount, 0 };
      
        return buffer[0] switch {
            byte bufferContent when !allowedPrefixes.Contains(bufferContent) => 0,
            ShortSignedPrefixByte => BitConverter.ToInt16(buffer, 1),
            IntSignedPrefixByte  => BitConverter.ToInt32(buffer, 1),
            _ => BitConverter.ToInt64(buffer, 1)
        };
    }

  

  
}
