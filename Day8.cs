using System.Buffers;

class Day8 {

    internal static void doit() {

        long sumA = 0;
        long sumB = 0;

        var dist = ((long, long, long) a, (long, long, long) b) => {
            var ax = a.Item1;
            var ay = a.Item2;
            var az = a.Item3;
            var bx = b.Item1;
            var by = b.Item2;
            var bz = b.Item3;
            return Math.Sqrt((ax-bx)*(ax-bx) + (ay-by)*(ay-by) + (az-bz)*(az-bz));
        };

        List<(long, long, long)> points = new();

        bool test = false;

        var inp = !test ? Helper.getInputAsLines(8) : """
            162,817,812
            57,618,57
            906,360,560
            592,479,940
            352,342,300
            466,668,158
            542,29,236
            431,825,988
            739,650,466
            52,470,668
            216,146,977
            819,987,18
            117,168,530
            805,96,715
            346,949,466
            970,615,88
            941,993,340
            862,61,35
            984,92,344
            425,690,689
            """.Trim().Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        int partAnum = test ? 10 : 1000;

        foreach (var item in inp) {
            var raw = item.Split(',');
            points.Add((long.Parse(raw[0]), long.Parse(raw[1]), long.Parse(raw[2])));
        }

        SortedDictionary<string, double> distances = new();

        for (int i = 0; i < points.Count; i++) {
            for (int j = i+1; j < points.Count; j++) {
                var d = dist(points[i], points[j]);
                distances.Add($"{i}-{j}", d);
            }
        }


        //Geht so NICHT, man muss ZUSÄTZLICH noch schauen, wie die direkten Connections sind und bei dern ersten 1000 die SKIPPEN, die sowieso schon direkt verbunden sind
        var erste1000 = distances.OrderBy(d => d.Value).Take(partAnum);
        List<List<int>> circuits = new();
        for (int i = 0; i < points.Count; i++) {
            circuits.Add(new List<int>() { i });
        }

        var addToCircuits = (KeyValuePair<string, double> distance) => {
            var nodes = distance.Key.Split('-').Select(s => int.Parse(s)).ToList();
            var node1 = nodes[0];
            var node2 = nodes[1];

            if (circuits.Any(a => a.Contains(node1) && a.Contains(node2)))
                //beide schon in EINEM circ, nix machen
                return;

            //finde Kreise
            var passende = circuits.Where(c => c.Contains(node1) || c.Contains(node2));
            //verbinden
            passende.First().AddRange(passende.Last());
            passende.Last().Clear();
            circuits = circuits.Where(c => c.Count > 0).ToList();
        };

        foreach (var distance in erste1000) {
            addToCircuits(distance);
        }

        var längen = circuits.Select(c => c.Count).ToList();
        var längste3 = längen.OrderDescending().Take(3);
        sumA = längste3.Aggregate(1L, (a, b) => a * b);

        foreach (var distance in distances.OrderBy(d => d.Value).Skip(partAnum)) {
            addToCircuits(distance);
            if (circuits.Count == 1) {
                //alles verbunden

                var nodes = distance.Key.Split('-').Select(s => int.Parse(s)).ToList();
                var p1 = points[nodes[0]];
                var p2 = points[nodes[1]];

                sumB = p1.Item1 * p2.Item1;
                break;
            }
        }

        Console.WriteLine($"result A: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}