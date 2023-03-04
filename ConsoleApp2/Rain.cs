using Newtonsoft.Json;

namespace ConsoleApp2
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double h1 { get; set; }
    }
}