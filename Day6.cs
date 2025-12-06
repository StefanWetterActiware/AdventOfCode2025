class Day6 {

    internal static void doit() {
        var inputLines = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        var values = inputLines.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToList();

        long sumA = 0;
        long sumB = 0;

        for(int i=0; i<values[0].Length; i++) {
            var op = values.Last()[i];
            var nums = values.Take(values.Count-1).Select(v => long.Parse(v[i]));
            switch (op) {
                case "+":
                    sumA += nums.Sum();
                    break;
                case "*":
                    sumA += nums.Aggregate(1L, (a,b) => a*b);
                    break;
            }
        }

        //Oh no ,Part2... Read it again from scratch
        var calcers = inputLines.Last();
        //calc start of columns
        var colStartIndexes = new List<int>();
        while (true) {
            int idxP = calcers.IndexOf('+', colStartIndexes.Count == 0 ? 0 : colStartIndexes.Last() + 1);
            int idxM = calcers.IndexOf('*', colStartIndexes.Count == 0 ? 0 : colStartIndexes.Last() + 1);

            if (idxP + idxM == -2)
                break;

            if (idxP == -1) idxP = int.MaxValue;
            if (idxM == -1) idxM = int.MaxValue;
            int idx = Math.Min(idxP, idxM);

            colStartIndexes.Add(idx);
        }

        var numLines = inputLines.Take(inputLines.Count() - 1);
        for (int i = 0; i<colStartIndexes.Count(); i++) {
            var colIdx = colStartIndexes[i];
            var op = calcers[colIdx].ToString();
            int width;
            if  (i == colStartIndexes.Count() - 1)
                width = inputLines.First().Length - colIdx;
            else
                width = colStartIndexes[i + 1] - colStartIndexes[i] -1;

            List<long> lineNos = new();
            for (int j = width -1; j>=0; j--) {
                width--;
                lineNos.Add(long.Parse(String.Join("", numLines.Select(a => a[colIdx + j])).Trim()));
            }
            switch (op) {
                case "+":
                    sumB += lineNos.Sum();
                    break;
                case "*":
                    sumB += lineNos.Aggregate(1L, (a, b) => a * b);
                    break;
            }
        }

        Console.WriteLine($"result A: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}