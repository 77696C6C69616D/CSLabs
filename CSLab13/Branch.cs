namespace CSLab13
{
    public partial class Branch
    {
        public int score = 0;
        public int mines = 0;
        public int attempts = 0;
        public int[,] MatrixInit(int size)
        {
            Random rn = new Random();
            attempts = (size * size) / 3;
            int[,] matrix = new int[size, size];
            int len = Convert.ToInt32(Math.Sqrt(matrix.Length));
            for (int inner = 0; inner < len; inner++)
            {
                for (int inner_inner = 0; inner_inner < len; inner_inner++)
                {
                    matrix[inner, inner_inner] = rn.Next(0, 2);
                    if (matrix[inner, inner_inner] == 1)
                    {
                        mines++;
                    }
                }
            }
            matrix[rn.Next(0, len), rn.Next(0, len)] = 0;
            return matrix;
        }
        public void DisplayField(int[,] matrix)
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
                    if (matrix[inner, inner_inner] == 3)
                    {
                        Console.Write("| x |");
                        continue;
                    }
                    if (matrix[inner, inner_inner] == 2)
                    {
                        Console.Write("| o |");
                        continue;
                    }
                    Console.Write("|   |");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{String.Concat(Enumerable.Repeat("-", Convert.ToInt32(Math.Sqrt(matrix.Length) * 5)))} \n");
        }
        public List<int> ChooseCell()
        {
            while (true)
            {
                List<int> cout = new List<int>();
                Console.Write("[Спроб:" + attempts + "][Мін:" + mines + "]" + "\n$ ");
                string inp = Console.ReadLine();
                string[] tmp = inp.Split(" ");
                try
                {
                    Convert.ToInt32(tmp[0]);
                    Convert.ToInt32(tmp[1]);
                }
                catch
                {
                    Console.WriteLine("![Аргументи мають бути числами]");
                    continue;
                }
                if (tmp.Length != 2)
                {
                    Console.WriteLine("![Введіть два аргумента]");
                    continue;
                }
                cout.Add(Convert.ToInt32(tmp[0]) - 1);
                cout.Add(Convert.ToInt32(tmp[1]) - 1);
                return cout;
            }
        }
        public bool IsBomb(int[,] matrix, List<int> stdin)
        {
            if (matrix[stdin[0], stdin[1]] == 1)
            {
                matrix[stdin[0], stdin[1]] = 3;
                mines--;
                score += 3;
                return true;
            }
            matrix[stdin[0], stdin[1]] = 2;
            attempts--;
            return false;
        }
        public string ConvertTimer(int time)
        {
            int tmp = time / 100;
            string cout = (tmp < 60) ? $"{tmp}" : $"{tmp / 60}";
            return cout;
        }
        public string StartGame()
        {
            score = 0;
            mines = 0;
            attempts = 0;
            int[,] matrix = MatrixInit(5);
            var Timer = System.Diagnostics.Stopwatch.StartNew();
            while (true)
            {
                break;
                DisplayField(matrix);
                IsBomb(matrix, ChooseCell());
                if (attempts == 0)
                {
                    Timer.Stop();
                    break;
                }
            }
            Console.Read();
            Timer.Stop();
            int time = Convert.ToInt32(Timer.ElapsedMilliseconds);
            string cout = $"Рахунок:{score} Час:{ConvertTimer(time)}";
            return cout;
        }


    }
}
