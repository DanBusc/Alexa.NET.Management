﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Skills
{
    public class CertificationSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public CertificationStatus Status { get; set; }

        [JsonProperty("skillSubmissionTimestamp")]
        public DateTime SubmissionTimestamp { get; set; }

        [JsonProperty("reviewTrackingInfo")]
        public ReviewTrackingSummary ReviewTracking { get; set; }

    }
}