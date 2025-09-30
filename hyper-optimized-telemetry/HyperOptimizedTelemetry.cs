public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        int prefix = 0;
        int payloadLength = 0;

        /*/If statements identify what the prefix will be for the returning buffer along with the payload size. This essentially
        indetifies the smallest type the value can be converted to.
        /*/

        if (reading >= short.MinValue && reading <= -1)
        {
            // short
            prefix = 254;
            payloadLength = 2;
        }
        else if (reading >= 0 && reading <= ushort.MaxValue)
        {
            // ushort
            prefix = 2;
            payloadLength = 2;
        }
        else if (reading >= ushort.MaxValue + 1 && reading <= int.MaxValue || reading >= int.MinValue && reading <= short.MinValue - 1)
        {
            //int
            prefix = 252;
            payloadLength = 4;
        }
        else if (reading >= (long)int.MaxValue + 1 && reading <= uint.MaxValue)
        {
            //uint
            prefix = 4;
            payloadLength = 4;
        }
        else if (reading >= (long)uint.MaxValue + 1 && reading <= long.MaxValue || reading >= long.MinValue && reading <= (long)int.MinValue - 1)
        {
            //long
            prefix = 248;
            payloadLength = 8;
        }

        byte[] payload = BitConverter.GetBytes(reading);

        buffer[0] = (byte)prefix;
        Buffer.BlockCopy(payload, 0, buffer, 1, payloadLength);

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        int prefix = buffer[0];
        long decoded = 0;
        bool isSigned;
        int payloadLength;

        if (prefix == 2 || prefix == 4)
        {
            isSigned = false;
            payloadLength = prefix;
        }
        else if (prefix == 248 || prefix == 252 || prefix == 254)
        {
            isSigned = true;
            payloadLength = 256 - prefix;
        }
        else
        {
            return 0;
        }

        byte[] payload = new byte[payloadLength];
        Array.Copy(buffer, 1, payload, 0, payloadLength);

        if (payloadLength == 2)
        {
            decoded = isSigned ? BitConverter.ToInt16(payload, 0) : BitConverter.ToUInt16(payload, 0);
        }
        else if (payloadLength == 4)
        {
            decoded = isSigned ? BitConverter.ToInt32(payload, 0) : BitConverter.ToUInt32(payload, 0);
        }
        else if (payloadLength == 8)
        {
            decoded = BitConverter.ToInt64(payload, 0);
        }

        return decoded;


    }
}
