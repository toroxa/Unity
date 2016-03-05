using Newtonsoft.Json;
using System.Collections.Generic;

namespace LLV.Models
{
    public class ResultModel<TData>
    {
        public ResultModel()
        {
            Errors = new List<string>();
        }

        [JsonProperty("ok")]
        public bool OK { get; set; }

        [JsonProperty("errors")]
        public IList<string> Errors { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }
    }

    public class ResultModel
    {
        public ResultModel()
        {
            Errors = new List<string>();
        }

        [JsonProperty("ok")]
        public bool OK { get; set; }

        [JsonProperty("errors")]
        public IList<string> Errors { get; set; }
    }
}