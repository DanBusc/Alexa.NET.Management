﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillManagementTests
    {
        [Fact]
        public async Task Unpublish()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/unpublish", req.RequestUri.PathAndQuery);
                var raw = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<UnpublishRequest>(raw);
                Assert.Equal(UnpublishType.Remove,request.Type);
                Assert.Equal(UnpublishReason.PublishedByMistake,request.Reason);
            }, new UnpublishResponse{Message="test"}));

            var response = await management.Skills.Unpublish("skillId",UnpublishType.Remove,UnpublishReason.PublishedByMistake);
            Assert.Equal("test",response.Message);
        }

        [Fact]
        public async Task SubmitManual()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillId/submit", req.RequestUri.PathAndQuery);
                var raw = await req.Content.ReadAsStringAsync();
                var request = JsonConvert.DeserializeObject<SubmitRequest>(raw);
                Assert.Equal(PublicationMethod.Manual, request.PublicationMethod);
                var resp = new HttpResponseMessage(HttpStatusCode.Accepted);
                resp.Headers.Location = new Uri("/testresponse",UriKind.Relative);
                return resp;
            }));

            var response = await management.Skills.Submit("skillId", false);
            Assert.Equal("/testresponse",response.Location.ToString());
        }
    }
}
