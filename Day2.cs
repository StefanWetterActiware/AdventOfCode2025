
class Day2 {
    internal static void doit(){
        var input = Helper.getInput(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        long sumA = 0;
        long sumB = 0;

        foreach (var line in input.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) {
            var parts = line.Split("-");
            for (var i = long.Parse(parts[0]); i <= long.Parse(parts[1]); i++)
            {
                var s = i.ToString();
                var l = s.Length;
                var l2 = l / 2;
                var s1 = s.Substring(0, l2);
                var s2 = s.Substring(l2);
                if (s1.Equals(s2))
                    sumA += i;

                for (int j = 1; j <= l2; j++)
                {
                    var p = s.Substring(0, j);
                    var q = s.Replace(p, "");
                    if (string.IsNullOrWhiteSpace(q))
                    {
                        sumB += i;
                        break;
                    }
                }
            }
        }

        Console.WriteLine($"result: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}