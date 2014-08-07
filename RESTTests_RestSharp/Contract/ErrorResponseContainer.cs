using System.Collections.Generic;

namespace RESTTests_RestSharp.Contract
{
    public class ErrorResponseContainer
    {
        public Error error { get; set; }
    }
    
    public class ErrorsList
    {
        public string domain { get; set; }
        public string code { get; set; }
        public string internalReason { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<ErrorsList> errors { get; set; }
    }
}
