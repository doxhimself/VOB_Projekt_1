public abstract class AlarmRule
{
    public event EventHandler<Alarm>? AlarmTriggered;
    
    public abstract void Check(TelemetrySample sample);
    protected void RaiseAlarm(Alarm alarm)
    {
        AlarmTriggered?.Invoke(this, alarm);
    }
}

