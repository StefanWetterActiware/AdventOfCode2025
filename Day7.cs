class Day7 {

    internal static void doit() {
        var inputLines = Helper.getInputAsLines(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value)).Select(a => a.ToCharArray()).ToList();

        long sumA = 0;
        long sumB = 0;

        for (int i = 1; i < inputLines.Count(); i++) {
            for (int j = 0; j < inputLines[0].Length; j++) {
                if (inputLines[i-1][j] == '.')
                    continue;

                if (inputLines[i-1][j] == 'S' || inputLines[i-1][j] == '|') {
                    if (inputLines[i][j] == '^') {
                        if (j != 0) {
                            inputLines[i][j-1] = '|';
                        }
                        if (j != inputLines[0].Length - 1) {
                            inputLines[i][j+1] = '|';
                        }
                        j++;
                        sumA++;
                    } else {
                        inputLines[i][j] = '|';
                    }
                }
            }
        }

        Console.WriteLine($"result A: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}