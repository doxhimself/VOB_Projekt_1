public class AlarmEngine
{
    private readonly List<AlarmRule> _rules = new();

    public event EventHandler<Alarm>? AlarmTriggered;

    public void AddRule(AlarmRule rule)                                                                                
  {                                                                                                                  
      rule.AlarmTriggered += OnAlarmTriggered;                                                                       
      _rules.Add(rule);                                                                                              
  }                  

    public void Process(TelemetrySample sample)
    {
        foreach (var rule in _rules)
            rule.Check(sample);
    }
    private void OnAlarmTriggered(object? sender, Alarm alarm)
    {
        AlarmTriggered?.Invoke(this, alarm);
    }
}
