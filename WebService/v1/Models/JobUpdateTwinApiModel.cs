// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using Microsoft.Azure.IoTSolutions.IotHubManager.Services.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Microsoft.Azure.IoTSolutions.IotHubManager.WebService.v1.Models
{
    public class JobUpdateTwinApiModel
    {
        [JsonProperty(PropertyName = "Etag", NullValueHandling = NullValueHandling.Ignore)]
        public string Etag { get; set; }

        [JsonProperty(PropertyName = "DeviceId", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; set; }

        [JsonProperty(PropertyName = "Properties", NullValueHandling = NullValueHandling.Ignore)]
        public TwinPropertiesApiModel Properties { get; set; }

        [JsonProperty(PropertyName = "Tags", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, JToken> Tags { get; set; }

        [JsonProperty(PropertyName = "IsSimulated")]
        public bool IsSimulated { get; set; }

        public JobUpdateTwinApiModel()
        {
            this.Tags = new Dictionary<string, JToken>();
            this.Properties = new TwinPropertiesApiModel();
        }

        public JobUpdateTwinApiModel(string deviceId, DeviceTwinServiceModel deviceTwin)
        {
            if (deviceTwin == null) return;


            this.Etag = deviceTwin.Etag;
            this.DeviceId = deviceId;
            this.Properties = new TwinPropertiesApiModel(deviceTwin.DesiredProperties, deviceTwin.ReportedProperties);
            this.Tags = deviceTwin.Tags;
            this.IsSimulated = deviceTwin.IsSimulated;
        }

        public DeviceTwinServiceModel ToServiceModel()
        {
            return new DeviceTwinServiceModel
            (
                etag: this.Etag,
                deviceId: this.DeviceId,
                desiredProperties: this.Properties.Desired,
                reportedProperties: this.Properties.Reported,
                tags: this.Tags,
                isSimulated: this.IsSimulated
            );
        }
    }
}
