namespace CSLab10
{
    class Prism
    { // Модуль обчислення значень ПРЯМОЇ призми //
        private double[] x = new double[] { 0, 0, 0 };
        private double[] y = new double[] { 0, 0, 0 };
        private double h = 3;
        public double h_
        {
            set { h = value; }
            get { return h; }
        }
        public double[] x_
        {
            set { x = value; }
            get { return x; }
        }
        public double[] y_
        {
            set { y = value; }
            get { return y; }
        }

        // Довжина вектора
        public static List<double> Vector_Length(double[] x, double[] y)
        {
            var sides = new List<double>();
            sides.Add(
                Math.Round(Math.Sqrt(Math.Pow(x[0] - x[1], 2) + Math.Pow(y[0] - y[1], 2)), 1)
            );
            sides.Add(
                Math.Round(Math.Sqrt(Math.Pow(x[1] - x[2], 2) + Math.Pow(y[1] - y[2], 2)), 1)
            );
            sides.Add(
                Math.Round(Math.Sqrt(Math.Pow(x[0] - x[2], 2) + Math.Pow(y[0] - y[2], 2)), 1)
            );
            return sides;
        }

        // Довжина ребер
        public static double Edge_Lenth(double h = 0)
        {
            return h;
        }

        // Площа основи // Трикутник (рівньосторонній, прямокутник, звичайний)
        public static double S_area(List<double> sides)
        {
            double p = (sides[0] + sides[1] + sides[2]) / 2;
            if (sides.Count() == 3 && sides[0] == sides[1] && sides[0] == sides[2])
                return (Math.Pow(sides[0], 2) * Math.Sqrt(3)) / 4;
            if (
                sides.Count() == 3
                && sides[2] == Math.Sqrt(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))
            )
                return (sides[0] * sides[1]) / 2;
            return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
        }

        // Периметр основи // Трикутник (рівньосторонній, прямокутник, звичайний)
        public static double P_area(List<double> sides)
        {
            return sides[0] + sides[1] + sides[2];
        }

        // Площа бічної поверхні
        public static double S_edge(List<double> sides, double h = 0)
        {
            return Prism.P_area(sides) * h;
        }

        // Площа повної поверхні
        public static double S_full(List<double> sides, double h = 0)
        {
            return 2 * Prism.S_area(sides) + Prism.S_edge(sides, h);
        }

        // Об'єм призми
        public static double V_prism(List<double> sides, double h = 0)
        {
            return S_area(sides) * h;
        }

        // Визначення фігури у основи
        public static string Figure_area(List<double> sides)
        {
            if (sides.Count() == 3 && sides[0] == sides[1] && sides[0] == sides[2])
                return "Рівньосторонній трикутник";
            if (
                sides.Count() == 3
                && sides[2] == Math.Sqrt(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))
            )
                return "Прямокутний трикутник";
            return "Трикутник";
        }

        public static bool Is_allow(double value_ = 0)
        {
            if (value_ > 0 && value_ < 250)
                return true;
            return false;
        }
    }

    class Program
    { // Головний модуль
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Prism prism = new Prism();
            var sides = new List<double>();
            while (true)
            {
                bool f = false;
                Console.Write("→ Висота: ");
                f = double.TryParse(Console.ReadLine(), out double inp);
                if (f == true && inp > 0)
                {
                    prism.h_ = inp;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("          ↪ Невірний тип даних");
                Console.ResetColor();
            }

            // Заповнення випадковими числами
            Random rand = new Random();
            for (int i = 0; i < prism.x_.Count(); ++i)
            {
                prism.x_[i] = rand.Next(0, 250);
                prism.y_[i] = rand.Next(0, 250);
            }

            // Console.WriteLine("\n→ Координати точок [0.0:250.0]:");
            // for (int i = 0; i < prism.x_.Count(); ++i) {
            //     while (true) {
            //         Console.Write($"    → x{i+1}: ");
            //         bool f = false;
            //         f = double.TryParse(Console.ReadLine(), out double inp);
            //         if (!Prism.Is_allow(inp) || f == false) {
            //             Console.ForegroundColor = ConsoleColor.DarkRed;
            //             Console.WriteLine("          ↪ Невірний тип даних");
            //             Console.ResetColor();
            //             continue; }
            //         prism.x_[i] = inp; break; }
            //     while (true) {
            //         Console.Write($"    → y{i+1}: ");
            //         bool f = false;
            //         f = double.TryParse(Console.ReadLine(), out double inp);
            //         if (!Prism.Is_allow(inp) || f == false) {
            //             Console.ForegroundColor = ConsoleColor.DarkRed;
            //             Console.WriteLine("          ↪ Невірний тип даних");
            //             Console.ResetColor();
            //             continue; }
            //         prism.y_[i] = inp; break; } }
            // sides = Prism.Vector_Length(prism.x_, prism.y_);
            Console.Write("\n→ x: ");
            for (int i = 0; i < prism.x_.Count(); ++i)
                Console.Write(+prism.x_[i] + " ");
            Console.Write("\n→ y: ");
            for (int i = 0; i < prism.y_.Count(); ++i)
                Console.Write(prism.y_[i] + " ");
            Console.WriteLine(
                "\n\n→ Основа:"
                    + "\n    → A: "
                    + sides[0]
                    + "\n    → B: "
                    + sides[1]
                    + "\n    → C: "
                    + sides[2]
                    + ((sides.Count() == 4) ? "\n    → D: " + sides[3] : "")
                    + "\n    ↪ Фігура у основи: "
                    + "["
                    + Prism.Figure_area(sides)
                    + "]"
                    + "\n        ↪  Периметр: "
                    + Math.Round(Prism.P_area(sides), 2)
                    + "\n        ↪  Площа: "
                    + Math.Round(Prism.S_area(sides), 2)
                    + "\n"
                    + "\n→ Характеристики призми:"
                    + "\n   ↪ Тип: [Пряма]"
                    + // Константа за т.з.
                    "\n        ↪ Довжина ребер: "
                    + Math.Round(Prism.Edge_Lenth(prism.h_), 2)
                    + "\n        ↪ Площа бічної поверхні: "
                    + Math.Round(Prism.S_edge(sides, prism.h_), 2)
                    + "\n        ↪ Площа повної поверхні: "
                    + Math.Round(Prism.S_full(sides, prism.h_), 2)
                    + "\n        ↪ Об'єм призми: "
                    + Math.Round(Prism.V_prism(sides, prism.h_), 2)
            );
            Console.WriteLine();
        }
    }
}
