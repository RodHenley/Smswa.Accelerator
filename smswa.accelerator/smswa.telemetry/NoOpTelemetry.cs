using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace smswa.telemetry
{
    public class NoOpTelemetry:ITelemetry
    {
        public T LogAndTimeOperation<T>(Func<T> operation, string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics)
        {
            return operation();
        }

        public void LogAndTimeOperation(Action operation, string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics)
        {
            operation();
        }
    }
}
