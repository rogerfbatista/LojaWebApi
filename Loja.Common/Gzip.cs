using System.IO;
using System.IO.Compression;

namespace Loja.Common
{
    public class Gzip
    {
        public static byte[] Decompress(byte[] gzip)
        {
            if (gzip == null)
            {
                return null;
            }
             const int size = 4096;
               
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            using (var stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {

               
                var buffer = new byte[size];
                using (var memory = new MemoryStream())
                {
                    var count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }

        public static byte[] Compress(byte[] raw)
        {
            if (raw == null)
            {
                return null;
            }
            using (var memory = new MemoryStream())
            {
                using (var gzip = new GZipStream(memory,CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }


    }
}
