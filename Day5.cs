class Day5 {

    internal static void doit() {
        var input = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        SortedDictionary<long,long> fresh = new();

        var e = input.GetEnumerator();
        while (true) {
            e.MoveNext();
            var line = e.Current;

            if (string.IsNullOrWhiteSpace(line))
                break;
            if (!line.Contains("-"))
                break;

            var p = line.Split('-');
            var up = long.Parse(p[1]);
            var low = long.Parse(p[0]);
            
            if (!fresh.ContainsKey(low))
                fresh.Add(low, up);
            else if (fresh[low] < up)
                fresh[low] = up;
        }

        long sumA = 0;
        long sumB = 0;

        do {
            long i = long.Parse(e.Current);

            sumA += fresh.Where(kv => kv.Key <= i && kv.Value >= i).Any() ? 1 : 0;
        } while (e.MoveNext());
        

        Console.WriteLine($"result: {sumA}");

        for (int i = 0; i < fresh.Count; i++) {
            var kv = fresh.Skip(i).Take(1).Single();

            //Overlapping...
            for (int j = 0; j < i; j++) {
                var kv2 = fresh.Skip(j).Take(1).Single();
                if (kv.Key >= kv2.Key && kv.Value <= kv2.Value) {
                    kv = new(0, -1); //fully overlapping, set to dummy, end
                    break;
                }
                if (kv.Key >= kv2.Key && kv.Key <= kv2.Value) {
                    kv = new KeyValuePair<long, long>(kv2.Value+1, kv.Value);
                }
                if (kv.Value >= kv2.Key && kv.Value <= kv2.Value) {
                    kv = new KeyValuePair<long, long>(kv.Key, kv2.Key-1);
                }
            }

            sumB += (kv.Value - kv.Key) + 1;
        }

        Console.WriteLine($"result B: {sumB}");
    }
}