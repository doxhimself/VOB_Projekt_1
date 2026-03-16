public sealed record TelemetrySample(
    DateTime Timestamp,
    string MachineId,
    double Temperature,
    double Vibration,
    double Current);