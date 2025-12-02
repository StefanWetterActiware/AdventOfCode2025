using System.Text.RegularExpressions;


class Day1 {
    internal static void doit(){
        Regex dayNoR = new(@"\d*$");
        var lines = Helper.getInputAsLines(int.Parse(dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        long sumA = 0;
        long sumB = 0;

        int dial = 50;

        foreach (var line in lines) {
            char direction = line[0];
            int num = int.Parse(line[1..]);
            if (direction == 'L')
                dial -= num;
            else
                dial += num;
            dial = dial % 100;
            sumA += dial == 0 ? 1 : 0;
        }

        Console.WriteLine($"result: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}