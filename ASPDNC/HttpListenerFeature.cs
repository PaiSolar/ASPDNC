using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using ASPDNC.Core.Http;

namespace ASPDNC {
    public class HttpListenerFeature : IRequestFeature, IResponseFeature {
        private readonly HttpListenerContext _context;

        Uri IRequestFeature.Url => _context.Request.Url;

        NameValueCollection IRequestFeature.Headers => _context.Request.Headers;
        NameValueCollection IResponseFeature.Headers => _context.Response.Headers;

        Stream IRequestFeature.Body => _context.Request.InputStream;

        Stream IResponseFeature.Body => _context.Response.OutputStream;

        public int StatusCode {
            get { return _context.Response.StatusCode; }
            set { _context.Response.StatusCode = value; }
        }       

        public HttpListenerFeature(HttpListenerContext context) => _context = context;
    }
}
