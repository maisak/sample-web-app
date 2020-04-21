using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Common.Toolbox.Logger
{
    public class AppInsightsLogger : ILogger
    {
        private readonly TelemetryClient _telemetry;
        private readonly Dictionary<string, string> _metadata = new Dictionary<string, string>();

        public AppInsightsLogger(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        public void Init(string rowKey, string runId)
        {
            _metadata.Add("RowKey", rowKey);
            _metadata.Add("RunId", runId);
        }

        public void LogAutomation(string message)
        {
            throw new NotImplementedException();
        }

        public void LogEvent(string eventName, string message)
        {
            LogEvent(eventName, message, new Dictionary<string, string>());
        }

        public void LogEvent(string eventName, string message, Dictionary<string, string> data)
        {
            var dictionary = MergeDictionary(data);
            dictionary.Add("Message", message);
            _telemetry.TrackEvent(eventName, dictionary);
        }

        public void LogException(Exception exception)
        {
            LogException(exception, new Dictionary<string, string>());
        }

        public void LogException(Exception exception, Dictionary<string, string> dictionary)
        {
            _telemetry.TrackException(exception, MergeDictionary(dictionary));
        }

        public void LogOperation<T>(string message, Dictionary<string, string> data)
        {
            var dictionary = MergeDictionary(data);
            dictionary.Add("Message", message);
            _telemetry.TrackEvent(typeof(T).Name, dictionary);
        }

        private Dictionary<string, string> MergeDictionary(Dictionary<string, string> dict)
        {
            return _metadata.Concat(dict).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
