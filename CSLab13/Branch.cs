namespace CSLab13
{
    public partial class Branch
    {

        public int[,] MatrixInit(int size, int score)
        {
            Random rn = new Random();
            int[,] matrix = new int[size, size];
            int len = Convert.ToInt32(Math.Sqrt(matrix.Length));
            int bomb;
            for (int inner = 0; inner < len; inner++)
            {
                for (int inner_inner = 0; inner_inner < len; inner_inner++)
                {   
                    matrix[inner, inner_inner] = rn.Next(0, 2);
                    if (matrix[inner, inner_inner] == 1) {
                        score = BombCount(1, score);
                    }
                }
            }
            matrix[rn.Next(0, len), rn.Next(0, len)] = 0;
            return matrix;
        }
        public void DisplayField(int[,] matrix, int score, string time)
        {
            Console.Clear();
            Console.Write(String.Concat(Enumerable.Repeat(" ", Convert.ToInt32(-5 + Math.Sqrt(matrix.Length) * 2.5))));
            Console.WriteLine("_________");
            Console.Write(String.Concat(Enumerable.Repeat(" ", Convert.ToInt32(-5 + Math.Sqrt(matrix.Length) * 2.5))));
            Console.WriteLine("| Сапер |");
            for (int inner = 0; inner < Math.Sqrt(matrix.Length); inner++)
            {
                Console.WriteLine(String.Concat(Enumerable.Repeat("-", Convert.ToInt32(Math.Sqrt(matrix.Length) * 5))));
                for (int inner_inner = 0; inner_inner < Math.Sqrt(matrix.Length); inner_inner++)
                {
                    // string cout = (matrix[inner, inner_inner] == 2) ? "| x |" : "|   |";
                    // Console.Write(cout);
                    Console.Write($"| {matrix[inner, inner_inner]} |");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{String.Concat(Enumerable.Repeat("-", Convert.ToInt32(Math.Sqrt(matrix.Length) * 5)))} \n");
            StatusBar(matrix, score, time);
        }
        public List<int> ChooseCell()
        {
            List<int> cout = new List<int>();
            Console.Write("$ ");
            string inp = Console.ReadLine();
            string[] tmp = inp.Split(" ");
            cout.Add(Convert.ToInt32(tmp[0]));
            cout.Add(Convert.ToInt32(tmp[1]));
            return cout;
        }
        public bool IsBomb(int[,] matrix, List<int> stdin, int score)
        {
            if (matrix[stdin[0], stdin[1]] == 1)
            {
                matrix[stdin[0], stdin[1]] = 2;
                score = BombCount(-1, score);
                return true;
            }
            return false;
        }
        public int BombCount(int inc, int score) { 
            score += inc;
            return score;
        }
        public void StatusBar(int[,] matrix, int score, string time) {
            Console.WriteLine("[ 💣 " + score + " ] - [ ⌚ `" + time + " ] \n");
        }

        public void StartGame()
        {
            int score = 0; 
            int[,] matrix = MatrixInit(5, score);
            string time = "15:20";

            Console.WriteLine(score);

            while (true) {
                break;

                DisplayField(matrix, score, time);
                IsBomb(matrix, ChooseCell(), score);
                

            }
            
            
        }



    }
}
