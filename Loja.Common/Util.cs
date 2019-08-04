using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;

namespace Loja.Common
{
    public class Util<T>  where T : class
    {

        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using (var memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }


        public static byte[] Compress(Stream input)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new DeflateStream(compressedStream, CompressionMode.Compress))
            {
                input.CopyTo(zipStream);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            var output = new MemoryStream();
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
            {
                zipStream.CopyTo(output);
                zipStream.Close();
                output.Position = 0;
                return output.ToArray();
            }
        }


        public void SetUpdateObject(ref T obj)
        {
            var propriedades = obj.GetType().GetProperties();

            foreach (var item in propriedades)
            {
                if (item.PropertyType.IsPrimitive) continue;
                if (!item.PropertyType.IsGenericType) continue;
                if (item.PropertyType.GetGenericTypeDefinition() == typeof (ICollection<>))
                {
                    item.SetValue(obj, null);
                }
            }
        }
    }
}
