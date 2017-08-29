// Copyright (c) Microsoft. All rights reserved.

using Microsoft.Azure.IoTSolutions.IotHubManager.Services.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.IoTSolutions.IotHubManager.WebService.v1.Models
{
    public class MethodResultApiModel
    {
        [JsonProperty(PropertyName = "Status", NullValueHandling = NullValueHandling.Ignore)]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "JsonPayload", NullValueHandling = NullValueHandling.Ignore)]
        public string JsonPayload { get; set; }

        public MethodResultApiModel(MethodResultServiceModel model)
        {
            if (model == null) return;

            this.Status = model.Status;
            this.JsonPayload = model.JsonPayload;
        }

        public MethodResultServiceModel ToServiceModel()
        {
            return new MethodResultServiceModel()
            {
                Status = this.Status,
                JsonPayload = this.JsonPayload
            };
        }
    }
}
