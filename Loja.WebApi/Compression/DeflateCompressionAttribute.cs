using System.IO;
using System.Net.Http;
using System.Web.Http.Filters;
using Ionic.Zlib;

namespace Loja.WebApi.Compression
{
    public class DeflateCompressionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actContext)
        {
            var content = actContext.Response.Content;
            var bytes = content == null ? null : content.ReadAsByteArrayAsync().Result;
            var zlibbedContent = bytes == null ? new byte[0] :
            CompressionHelper.DeflateByte(bytes);
            actContext.Response.Content = new ByteArrayContent(zlibbedContent);
            if (content != null)
            {
                foreach (var httpContentHeader in content.Headers)
                {
                    actContext.Response.Content.Headers.Add(httpContentHeader.Key, httpContentHeader.Value);
                }
            }
            base.OnActionExecuted(actContext);
        }
    }

    public class CompressionHelper
    {
        public static byte[] DeflateByte(byte[] str)
        {
            if (str == null)
            {
                return null;
            }

            using (var output = new MemoryStream())
            {
                using (
                    var compressor = new DeflateStream(
                    output, CompressionMode.Compress,
                    CompressionLevel.BestSpeed))
                {
                    compressor.Write(str, 0, str.Length);
                }

                return output.ToArray();
            }
        }
    }

}