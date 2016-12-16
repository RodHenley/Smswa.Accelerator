using System;
using System.Collections.Generic;

namespace smswa.telemetry
{
    public enum TelemetryMetrics
    {
        Runtime
    }

    public interface ITelemetry
    {
        T LogAndTimeOperation<T>(Func<T> operation, string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics);
        void LogAndTimeOperation(Action operation, string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics);
        //void LogOperation(string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics, long runtime);
        //void LogOperation(string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics);
        //void LogAndTimeEventLoop(string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics, Action<EventHandler> attachStart, Action<EventHandler> detachStart, Action<EventHandler> attachEnd, Action<EventHandler> detachEnd);
        //void LogEvent(string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics, Action<EventHandler> attachStart);
    }
}