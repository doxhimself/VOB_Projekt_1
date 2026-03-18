using System.Globalization;

public static class TelemetryReader
{
    public static IEnumerable<TelemetrySample> ReadTelemetrySamples(string filePath)
    {
        using var reader = new StreamReader(filePath);

        _ = reader.ReadLine();

        int lineNumber = 1;

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            lineNumber++;
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split(';');
            if (parts.Length != 6)
            {
                Console.WriteLine($"Invalid line {lineNumber}: {line}");
                continue;
            }
            
            if (!DateTime.TryParse(parts[0].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.None, out var timestamp))
                continue;

            var machineId = parts[1].Trim();

            if (!double.TryParse(parts[2].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var temperature))
                continue;
            if (!double.TryParse(parts[3].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var vibration))
                continue;
            if (!double.TryParse(parts[4].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var current))
                continue;
            if (!double.TryParse(parts[5].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out var pressure))
                continue;

            yield return new TelemetrySample(timestamp, machineId, temperature, vibration, current, pressure);
        }
    }
}