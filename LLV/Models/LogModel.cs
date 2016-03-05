using Newtonsoft.Json;

namespace LLV.Models
{
    public class LogModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        /*
         * DEBUG = 1,
         * INFO  = 2,
         * WARN  = 3,
         * ERROR = 4,
         * FATAL = 5
         */
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}