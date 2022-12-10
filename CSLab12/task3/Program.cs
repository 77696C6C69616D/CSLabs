// Завдання 3
namespace CSLab12Task3
{
    class Line { 
        private string [] LineName = new string [] {"z", "z"};
        private double [] PointCoordinate = new double[] {0, 0, 0, 0};
        public string[] LName { 
            set { LineName = value; }
            get { return LineName; }
        }
        public double[] LPoint { 
            set { PointCoordinate = value; }
            get { return PointCoordinate; }
        }
        public string[] GetLName()
        {
            return LName;
        }
        // Функція введення даних щодо точок (назва та координати)
        public void LineIn () { 
            
            for (int index = 0; index < LineName.Count(); index++)
            {
                Console.Write($"> Пряма {index + 1}: ");
                LName[index] = Console.ReadLine();
            }
            for (int index = 0; index < PointCoordinate.Count(); index++)
            {
                while (true) { 
                bool f = false;
                string cmessage = (index < PointCoordinate.Count()/2 ) ? ("x: ") : ("y: ");
                Console.Write("> " + cmessage);
                f = double.TryParse(Console.ReadLine(), out double inp);
                if (f == true) {
                    LPoint[index] = inp;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("  ↪ Невірний тип даних");
                Console.ResetColor();
                }
            }        
        }
        // Функція виведення даних щодо точок (назва та координати)
        public void LineOut() { 
            Console.WriteLine("Точки на площині: ");
            for (int index = 0; index < LineName.Count(); index++)
            {
                Console.WriteLine($"    {LineName[index]}({PointCoordinate[index]};{PointCoordinate[index + 2]})");
            }
        }
        // Функція перетворення ASCII списку у текст (Unicode)
        public void ConvertAsciiToString (int[] ASCII_OUT) { 
            string cout = "";
            for (int index = 0; index < ASCII_OUT.Count(); index++)
            {
                char character = (char) ASCII_OUT[index];
                cout += character.ToString();
            }            
            Console.WriteLine(cout);
        }
    }    
    class Program
    {
        public static void Main () { 
            Console.Clear();
            Line l = new Line ();    
            // Список ASCII для перетворення та виведення у вигляді текста        
            int[] ASCII_OUT = new int [] {65, 83, 67, 73, 73, 58, 32, 75, 111, 99, 104, 101, 114, 122, 104, 101, 110, 107, 111, 32, 82, 111, 109, 97, 110};
            l.ConvertAsciiToString(ASCII_OUT); 
            Console.WriteLine("Група: П-310 \nПризначення: введення та виведення даних щодо 2-х прямих на площині\n");
            // Функції введення / виведення полей класу
            l.LineIn();
            Console.Clear();
            l.LineOut();
        }
    }
}