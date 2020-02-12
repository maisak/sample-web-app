using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Sample.Common.Toolbox;

namespace Sample.Middleware
{
    public class CustomTelemetryInitializer : ITelemetryInitializer
    {
        private const string InstanceId = "InstanceId";

        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry is ISupportProperties itemProperties &&
                !itemProperties.Properties.ContainsKey(InstanceId))
            {
                itemProperties.Properties[InstanceId] = EnvironmentConfig.InstanceId;
            }
        }
    }
}
