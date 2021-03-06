﻿using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class SharedSlotType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}