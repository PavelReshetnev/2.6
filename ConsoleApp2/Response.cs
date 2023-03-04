using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    public class Response
    {
        public Coord coord;
        public List<Weather> weather;
        [JsonProperty("base")]
        public string basis;
        public Main main;
        public int visibility;
        public Wind wind;
        public Rain rain;
        public Clouds clouds;
        public int timezone;
        public int id;
        public string name;
        public int code;

    }
}