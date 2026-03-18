var engine = new AlarmEngine();
engine.AddRule(new HighTemperatureRule(70.0));
engine.AddRule(new HighVibrationRule(10.0));

engine.AlarmTriggered += (sender, alarm) =>
{
    Console.WriteLine($"[{alarm.Timestamp}] ALARM on {alarm.MachineId} | {alarm.RuleName}: {alarm.Message}");
};

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "telemetry.csv");

foreach (var sample in TelemetryReader.ReadTelemetrySamples(filePath))
{
    engine.Process(sample);
    Thread.Sleep(200);
}
