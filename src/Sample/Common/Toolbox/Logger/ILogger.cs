using System;
using System.Collections.Generic;

namespace Sample.Common.Toolbox.Logger
{
    public interface ILogger
    {
        void Init(string rowKey, string runId);
        void LogAutomation(string message);
        void LogEvent(string eventName, string message);
        void LogEvent(string eventName, string message, Dictionary<string, string> data);
        void LogException(Exception exception);
        void LogException(Exception exception, Dictionary<string, string> dictionary);
        void LogOperation<T>(string message, Dictionary<string, string> data);
    }
}