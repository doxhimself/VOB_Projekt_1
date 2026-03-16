public sealed record TelemetrySample(
    DateTime Timestamp,
    string MachineId,
    double Temeperature,
    double Vibration,
    double Current);