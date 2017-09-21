// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using Microsoft.Azure.IoTSolutions.IotHubManager.Services.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.IoTSolutions.IotHubManager.WebService.v1.Models
{
    public class DeviceListApiModel
    {
        [JsonProperty(PropertyName = "$metadata")]
        public Dictionary<string, string> Metadata => new Dictionary<string, string>
        {
            { "$type", "DeviceList;" + Version.NUMBER },
            { "$uri", "/" + Version.PATH + "/devices" }
        };

        [JsonProperty(PropertyName = "ContinuationToken", NullValueHandling = NullValueHandling.Ignore)]
        public string ContinuationToken { get; set; }

        [JsonProperty(PropertyName = "Items", NullValueHandling = NullValueHandling.Ignore)]
        public List<DeviceRegistryApiModel> Items { get; set; }

        public DeviceListApiModel()
        {
        }

        public DeviceListApiModel(DeviceServiceListModel devices)
        {
            this.Items = new List<DeviceRegistryApiModel>();

            if (devices == null) return;

            this.ContinuationToken = devices.ContinuationToken;
            foreach (var d in devices.Items) this.Items.Add(new DeviceRegistryApiModel(d));
        }
    }
}
