﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.SlotType;
using Refit;
using Version = Alexa.NET.Management.SlotType.Version;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSlotTypeApi
    {
        [Post("/skills/api/custom/interactionModel/slotTypes")]
        Task<CreateSlotResponse> Create([Body]CreateSlotRequest request);

        [Get("/skills/api/custom/interactionModel/slotTypes/{slotId}")]
        Task<GetSlotResponse> Get(string slotId);

        [Post("/skills/api/custom/interactionModel/slotTypes/{slotId}/update")]
        Task<HttpResponseMessage> Update(string slotId, [Body]UpdateSlotRequest request);

        [Get("/skills/api/custom/interactionModel/slotTypes?vendorId={vendorId}")]
        Task<ListSlotResponse> List(string vendorId, SortDirection sortDirection);

        [Get("/skills/api/custom/interactionModel/slotTypes?vendorId={vendorId}")]
        Task<ListSlotResponse> List(string vendorId, int maxResults, SortDirection sortDirection);

        [Get("/skills/api/custom/interactionModel/slotTypes?vendorId={vendorId}")]
        Task<ListSlotResponse> List(string vendorId, string nextToken);

        [Delete("/skills/api/custom/interactionModel/slotTypes/{slotId}")]
        Task<HttpResponseMessage> Delete(string slotId);

        [Post("/skills/api/custom/interactionModel/slotTypes/{slotId}/versions")]
        Task<HttpResponseMessage> CreateVersion(string slotId, [Body]Version definition);

        [Get("/skills/api/custom/interactionModel/slotTypes/{slotId}/versions/{versionId}")]
        Task<CreatedVersion> GetVersion(string slotId, string versionId);

        [Get("/skills/api/custom/interactionModel/slotTypes/{slotId}/updateRequest/{updateRequestId}")]
        Task<SlotBuildStatus> BuildStatus(string slotId, string updateRequestId);
    }
}
