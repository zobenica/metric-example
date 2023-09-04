using System.Diagnostics.Metrics;

namespace MetricExample.Api;

public class CustomMetric
{
    static Meter s_meter = new("RFQ.Metric", "1.0.0");
    static Counter<int> rfqs = s_meter.CreateCounter<int>("RFQ completed",
        "RFQ",
        "Completed RFQ");
    private static Histogram<double> responseTime = s_meter.CreateHistogram<double>
    ("RFQ_processing_time"
    ,unit:"ms", "Processing time per RFQ");
    public void Add(int i = 1)
    {
        rfqs.Add(i);
        responseTime.Record(new Random().Next(1000, 10000));
    }
}