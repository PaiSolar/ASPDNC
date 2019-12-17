using System;
using System.Collections.Specialized;
using System.IO;

namespace ASPDNC.Core.Http {
    public interface IRequestFeature {
        Uri Url { get; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }
    public interface IResponseFeature {
        int StatusCode { get; set; }
        NameValueCollection Headers { get; }
        Stream Body { get; }
    }
}
