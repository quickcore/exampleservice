using System;
using System.Collections.Generic;
using System.Text;

namespace QuickCore.Client
{

    [Serializable]
    public class ApiResponseException : Exception
    {
        public ApiResponseException() { }
        public ApiResponseException(string message) : base(message) { }
        public ApiResponseException(string message, Exception inner) : base(message, inner) { }
        protected ApiResponseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
