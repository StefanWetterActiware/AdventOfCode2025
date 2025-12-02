
class Day3 {
    internal static void doit(){
        var input = Helper.getInput(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));

        long sumA = 0;
        long sumB = 0;
        

        Console.WriteLine($"result: {sumA}");
        Console.WriteLine($"result B: {sumB}");
    }
}