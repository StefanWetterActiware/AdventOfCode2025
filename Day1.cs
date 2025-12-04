
class Day1 {
    internal static void doit(){
        var lines = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        long sumA = 0;
        long sumB = 0;

        int dial = 50;

        foreach (var line in lines) {
            char direction = line[0];
            int num = int.Parse(line[1..]);
            
            //Ganze Hunderter schon auf B, spielen keine Rolle für die Drehung später
            sumB += num / 100;
            num = num % 100;

            if (direction == 'L') {
                if (dial == 0)
                    dial += 100;

                dial -= num;
                sumB += (dial < 1) ? 1 : 0;
            } else {
                dial += num;
                sumB += (dial > 99) ? 1 : 0;
            }

            //Normalisieren
            dial = dial % 100;
            if (dial < 0)
                dial += 100;

            sumA += dial == 0 ? 1 : 0;
        }

        Console.WriteLine($"result: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}