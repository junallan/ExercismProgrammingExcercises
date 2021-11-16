using System;
using System.Collections.Generic;
using System.Linq;

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
        var allowedPrefixes = new List<int>{ BitsInByte - LongByteCount, BitsInByte - IntByteCount, BitsInByte - ShortByteCount, ShortByteCount, IntByteCount, 0 };
        var prefixBuffer = (int)buffer[0];
        if (!allowedPrefixes.Contains(prefixBuffer))
        {
            return 0;
        }

        //buffer[0] = 0;
        //buffer[0] = 0xff;
        //     buffer[1] = 0;
        //buffer[2] = 0;
        //buffer[3] = 0;
        //buffer[4] = 0;
        //buffer[5] = 0;
        //buffer[6] = 0;
        //buffer[7] = 0;
        //buffer[8] = 0;
        //Array.Reverse(buffer);

        if ((BitsInByte - ShortByteCount) == prefixBuffer)
            return BitConverter.ToInt16(buffer, 1);
        else if ((BitsInByte - IntByteCount) == prefixBuffer)
            return BitConverter.ToInt32(buffer, 1);
        else return BitConverter.ToInt64(buffer, 1);

        // reading = reading >>1;
        //if// (UInt32.MinValue < reading && reading <= Int64.MaxValue) //result[0] = BitsInByte - LongByteCount;
        //    return 5; //+ LongByteCount;;

        // return reading;
    }
}
