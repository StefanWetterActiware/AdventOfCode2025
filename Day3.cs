
class Day3 {
    internal static void doit(){
        var banks = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));
        
        long sumA = 0;
        long sumB = 0;

        foreach (var bank in banks)
        {
            for (int i = 99; i >= 0; i--)
            {
                int zehner = i / 10;
                var einer = i % 10;
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(zehner + ".*" + einer);
                if (r.IsMatch(bank))
                {
                    sumA += i;
                    break;
                }
            }
        }

        Console.WriteLine($"result: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}