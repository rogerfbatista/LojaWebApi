#region License

//Todos Direitos reservardo SonicTI

#endregion

#region References

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

#endregion


namespace Loja.WebApi.Compression
{

    /// <summary>
    /// Adicionar atributo DeflateCompressionAttribute ao metodo de retorno
    /// </summary>
    public class CompressedRequestHandler : DelegatingHandler
    {
        #region Métodos

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return
                base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>((responseToCompleteTask) =>
                {
                    HttpResponseMessage response = responseToCompleteTask.Result;

                    if (response.RequestMessage.Headers.AcceptEncoding != null &&
                        response.RequestMessage.Headers.AcceptEncoding.Count > 0)
                    {

                        response.Content = new CompressedContent(response.Content, "deflate");
                    }

                    return response;
                },
                    TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        #endregion

    }

    public class CompressedContent : HttpContent
    {
        #region Propriedades

        private readonly HttpContent _originalContent;
        private readonly string _encodingType;

        #endregion

        #region Construtor

        public CompressedContent(HttpContent content, string encodingType)
        {


            if (encodingType != null && content != null)
            {



                _originalContent = content;
                _encodingType = encodingType.ToLowerInvariant();

                if (_encodingType != "gzip" && _encodingType != "deflate")
                {
                    throw new InvalidOperationException(
                        string.Format("Encoding '{0}' is not supported. Only supports gzip or deflate encoding.",
                            _encodingType));
                }

                // copy the headers from the original content
                foreach (KeyValuePair<string, IEnumerable<string>> header in _originalContent.Headers)
                {
                    Headers.TryAddWithoutValidation(header.Key, header.Value);
                }

                Headers.ContentEncoding.Add(encodingType);
            }
        }
        #endregion

        #region Métodos

        protected override bool TryComputeLength(out long length)
        {
            length = -1;

            return false;
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Stream compressedStream = new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true);

           return (_originalContent == null)? Task.Run(() => GetMensagem()):
               _originalContent.CopyToAsync(compressedStream).ContinueWith(tsk =>
            { if (compressedStream != null) compressedStream.Dispose(); });
        }

        public string GetMensagem()
        {
            return "Success";
        }
    }

    #endregion

}