using System.Buffers;

class Day9 {

    internal static void doit() {

        long sumA = 0;
        long sumB = 0;

        bool test = false;

        var inp = !test ? Helper.getInputAsLines(9) : """
            7,1
            11,1
            11,7
            9,7
            9,5
            2,5
            2,3
            7,3
            """.Trim().Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        List<(int, int)> points = new();

        foreach (var line in inp) {
            var parts = line.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            points.Add((int.Parse(parts[0]), int.Parse(parts[1])));
        }

        for (int i = 0; i < points.Count; i++) {
            for (int j = i + 1; j < points.Count; j++) {
                sumA = Math.Max(sumA, ((long)Math.Abs(points[i].Item1 - points[j].Item1 + 1)) * ((long)Math.Abs(points[i].Item2 - points[j].Item2 + 1)));
            }
        }


        Console.WriteLine($"result A: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}