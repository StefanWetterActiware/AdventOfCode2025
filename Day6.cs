class Day6 {

    internal static void doit() {
        var input = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        var values = input.Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToList();

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

        Console.WriteLine($"result A: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}