public class AlarmEngine
{
    private readonly List<AlarmRule> _rules = new();

    public event EventHandler<Alarm>? AlarmTriggered;

