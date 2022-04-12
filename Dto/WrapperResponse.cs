using Newtonsoft.Json;

namespace ProyectoBCP_API.Dto
{
    public class WrapperResponse<T> where T : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Result { get; set; }

        public WrapperResponse() { }

        public WrapperResponse(string message)
        {
            Success = false;
            Message = message;
            Result = null;
        }

        public WrapperResponse(T result)
        {
            Success = true;
            Result = result;
        }
    }
}