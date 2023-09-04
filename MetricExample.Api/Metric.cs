using System.Diagnostics.Metrics;

namespace MetricExample.Api;

public class CustomMetric
{
    static Meter meter = new Meter("RFQ.PricingBroker", "1.0.0");

    static Counter<int> meterRfqSuccess = meter.CreateCounter<int>("RFQcompleted", "{rfq}", "RFQ with status quoted");

    static Counter<int> meterRfqError = meter.CreateCounter<int>("RFQerrored", "{rfq}", "RFQ with status fail or error");

    static Histogram<double> rfqAvgResponseTime = meter.CreateHistogram<double>("RFQresponseTime", "{ms}", "Rfq avg processing time");

    
    public void Add(int i = 1)
    {
        meterRfqSuccess.Add(i * 2);
        meterRfqError.Add(i);
        rfqAvgResponseTime.Record(new Random().Next(1000, 10000));
    }
}