public class HighTemperatureRule : AlarmRule
{
    private double _threshold;
    public HighTemperatureRule(double threshold)
    {
        _threshold = threshold;
    }
    public override void Check(TelemetrySample sample)
    {
        if (sample.Temperature > _threshold)
        {
            var alarm = new Alarm
            {
                Timestamp = sample.Timestamp,  
                MachineId = sample.MachineId,
                RuleName = "HighTemperature",
                Message = $"Temperature {sample.Temperature} exceeds threshold {_threshold}"
            };
            AlarmTriggered?.Invoke(this, alarm);
        }
    }
}