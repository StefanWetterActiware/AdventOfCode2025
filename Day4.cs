
class Day4 {
    static char[][] grid=[];
    static int width = 0;
    static int height = 0;

    static int getNeighborCount(int x, int y) {
        int count = 0;
        for (int dx = -1; dx <= 1; dx++) {
            for (int dy = -1; dy <= 1; dy++) {
                if (x+dx < 0 || y+dy < 0) continue;
                if (x+dx > width-1 || y+dy > height-1) continue;
                if (grid[x+dx][y+dy] == '@') {
                    count++;
                }
            }
        }
        return count;
    }

    internal static void doit(){
        grid = Helper.getInputAsCharArray(int.Parse(Helper.dayNoR.Match(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name).Value));
        
        long sumA = 0;
        long sumB = 0;

        width = grid.Length;
        height = grid[0].Length;

        for (int x=0; x<width; x++) {
            for (int y=0; y<height; y++) {
                var c = grid[x][y];
                if (c == '.') continue;

                int neighbors = getNeighborCount(x,y);

                if (neighbors <=4) {
                    sumA ++;
                }
            }
        }
        Console.WriteLine($"result: {sumA}");

        //Part 2
        bool removedsome=true;
        while (removedsome) {
            removedsome = false;
            Console.WriteLine("New Round, current B: " + sumB);
            for (int x=0; x<width; x++) {
                for (int y=0; y<height; y++) {
                    var c = grid[x][y];
                    if (c == '.') continue;

                    int neighbors = getNeighborCount(x,y);

                    if (neighbors <=4) {
                        sumB++;
                        grid[x][y] = '.';
                        removedsome = true;
                    }
                }
            }
        }

        Console.WriteLine($"result B: {sumB}");
    }
}