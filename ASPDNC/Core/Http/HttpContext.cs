﻿using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace ASPDNC.Core.Http {
    public class HttpContext {
        public HttpRequest Request { get; }
        public HttpResponse Response { get; }

        public HttpContext(IFeatureCollection features) {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
    }

    public class HttpRequest {
        private readonly IRequestFeature _feature;

        public Uri Url => _feature.Url;

        public NameValueCollection Headers => _feature.Headers;

        public Stream Body => _feature.Body;

        public HttpRequest(IFeatureCollection features) => _feature = features.Get<IRequestFeature>();
    }

    public class HttpResponse {
        private readonly IResponseFeature _feature;

        public NameValueCollection Header => _feature.Headers;

        public Stream Body => _feature.Body;

        public int StatusCode { get => _feature.StatusCode; set => _feature.StatusCode = value; }

        public HttpResponse(IFeatureCollection features) => _feature = features.Get<IResponseFeature>();
    }

    public static partial class Extensions {
        public static Task WriteAsync(this HttpResponse response, string contents) {
            var buffer = Encoding.UTF8.GetBytes(contents);
            return response.Body.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
