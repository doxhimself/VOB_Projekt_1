public class HighVibrationRule : AlarmRule
{
    private double _threshold;

    public HighVibrationRule(double threshold)
    {
        _threshold = threshold;
    }

    public override void Check(TelemetrySample sample)
    {
        if (sample.Vibration > _threshold)
        {
            var alarm = new Alarm
            {
                Timestamp = sample.Timestamp,
                MachineId = sample.MachineId,
                RuleName = "HighVibration",
                Message = $"Vibration {sample.Vibration} exceeds threshold {_threshold}"
            };
            RaiseAlarm(alarm);
        }
    }
}
