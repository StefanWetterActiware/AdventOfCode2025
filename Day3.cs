
class Day3 {
    
    internal static long getNumber(string bank, int length) {
        var schongecheckt=0;
        var x = getBiggest(bank, length);

        if (length == 1) {
            return long.Parse(x.ToString());
        }

        int index = bank.IndexOf(x, schongecheckt);
        
        long curmax = 0;

        while (index > -1) {
            var subbank = bank.Substring(index + 1);
            if (subbank.Length < length - 1) {
                break;
            }

            var num = long.Parse($"{x}{getNumber(subbank, length -1)}");
            curmax = Math.Max(curmax, num);

            schongecheckt = index + 1;
            index = bank.IndexOf(x, schongecheckt);
        }
        return curmax;
    }

    internal static char getBiggest(string s, int neededLength){
        var s2 = s.Substring(0, s.Length - neededLength+1);
        return s2.Max();
    }

    internal static void doit(){
        var banks = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));
        
        long sumA = 0;
        long sumB = 0;

        foreach (var bank in banks)
        {
            for (int i = 99; i >= 0; i--) {
                int zehner = i / 10;
                var einer = i % 10;
                System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(zehner + ".*" + einer);
                if (r.IsMatch(bank)) {
                    sumA += i;
                    break;
                }
            }

            sumB += getNumber(bank, 12);
        }

        Console.WriteLine($"result: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}