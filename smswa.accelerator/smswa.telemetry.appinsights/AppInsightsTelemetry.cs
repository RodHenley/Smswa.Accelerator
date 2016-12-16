using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using Microsoft.ApplicationInsights.Web;
using Microsoft.ApplicationInsights.WindowsServer;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;

namespace smswa.telemetry.appinsights
{
    public class AppInsightsTelemetry:ITelemetry
    {
        private TelemetryClient _client;

        public AppInsightsTelemetry():this(Guid.NewGuid())
        {
        }

        public AppInsightsTelemetry(Guid session)
        {
            TelemetryConfiguration.Active.InstrumentationKey = "a11b9e48-55fe-4efa-aec7-44e7a8905577";
            var performanceModule = new PerformanceCollectorModule();
            performanceModule.Initialize(TelemetryConfiguration.Active);


            var quickPulseModule = new QuickPulseTelemetryModule();
            quickPulseModule.Initialize(TelemetryConfiguration.Active);


            var webModule = new RequestTrackingTelemetryModule();
            webModule.Initialize(TelemetryConfiguration.Active);

            var exceptionModule = new UnhandledExceptionTelemetryModule();
            exceptionModule.Initialize(TelemetryConfiguration.Active);

            _client = new TelemetryClient(TelemetryConfiguration.Active);
        }
        
        public T LogAndTimeOperation<T>(Func<T> operation, string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics)
        {
            Stopwatch stopwatch = null;
            stopwatch = Stopwatch.StartNew();

            T result;
            try
            {
                result = operation();
            }
            catch (Exception ex)
            {
                DoTelemetryException(ex);
                throw;
            }
            finally
            {
                DoTimedTelemetry(eventName, context, metrics, stopwatch);
            }

            return result;

        }

        public void LogAndTimeOperation(Action operation, string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics)
        {
            Stopwatch stopwatch = null;
            try
            {
                stopwatch = Stopwatch.StartNew();
            }
            finally
            {
                //continue
            }

            try
            {
                operation();
            }
            catch (Exception ex)
            {
                DoTelemetryException(ex);
                throw;
            }
            finally
            {
                DoTimedTelemetry(eventName, context, metrics, stopwatch);
            }
        }

        private void DoTimedTelemetry(string eventName, Dictionary<string, string> context, Dictionary<string, double> metrics, Stopwatch stopwatch)
        {
            try
            {
                if (metrics == null)
                {
                    metrics = new Dictionary<string, double> { { TelemetryMetrics.Runtime.ToString(), TimeSpan.FromTicks(stopwatch.ElapsedTicks).TotalMilliseconds } };
                }
                else
                {
                    metrics.Add(TelemetryMetrics.Runtime.ToString(), TimeSpan.FromTicks(stopwatch.ElapsedTicks).TotalMilliseconds);
                }

                _client.TrackEvent(eventName, context, metrics);
            }
            finally
            {
                //continue
            }
        }

        private void DoTelemetryException(Exception ex)
        {
            try
            {
                _client.TrackException(ex);
            }
            finally
            {
                //continue
            }
        }

    }
}
