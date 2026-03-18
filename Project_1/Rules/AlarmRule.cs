public abstract class AlarmRule
{
    public event EventHandler<Alarm> AlarmTriggered;
    public abstract void Check(TelemetrySample sample);
}