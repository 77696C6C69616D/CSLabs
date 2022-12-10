namespace CSLab9{
    class File_{        

        // Фукція запису рядків файла text1.txt у файл text2.txt, без урахування порожніх рядків
        public static void Remove_Line(string file1_, string file2_){            
            StreamReader sr = File.OpenText(file1_);
            StreamWriter sw = new StreamWriter(file2_);            
            var lines_ = new List<string>();            
            for (int i = 0; i < File.ReadLines(file1_).Count(); ++i){
                string line_ = sr.ReadLine();
                if (line_ != "" && line_ != " ") 
                    lines_.Add(line_);}                                                
            for (int i = 0; i < lines_.Count(); ++i){                                                                        
                if (i == lines_.Count()-1){                    
                    sw.Write(lines_[i]);
                    continue;}
                sw.WriteLine(lines_[i]);}                
            sr.Close();
            sw.Close();}
        
        // Функція заповнення файла "number1.txt" випадковими числами із розбивкою на рядки
        public static void File_RandFill(string file_,int number_count,int numbers_per_row){            
            Random rand = new Random();
            StreamWriter sw = new StreamWriter(file_); int i = 0; 
            while (true){ 
                for (int j = 0; j < numbers_per_row; ++j){  
                    // За замовчуванням стоїть діапазон -10:10 у зв'язку з завеликою величиною факторіалу деяких чисел
                    int number = rand.Next(-10, 10);
                    // int number = rand.Next(-100, 100);
                    Console.Write(number + " ");                    
                    sw.Write(number + " ");                    
                    ++i; 
                    if (i >= number_count) 
                        break;}                                
                if (i >= number_count) 
                    break;       
                Console.WriteLine();         
                sw.WriteLine();}                  
            sw.Close();}
        
        // Функція виведення даних файла в термінал 
        public static void Read_File(string file_){
            StreamReader sr = File.OpenText(file_);
            int file_size = File.ReadLines(file_).Count();  
            for (int i = 0; i < file_size; ++i){
                string line_ = sr.ReadLine();                            
                Console.WriteLine(line_);}
            sr.Close();}

        // Функція заповнення файла "number3.txt" факторіалами позитивних чисел з "number1.txt" 
        public static void Write_Factorial(string file_,List<int> number1_values, int numbers_per_row){             
            StreamWriter sw = new StreamWriter(file_); int i = 0, n = 0; 
            int number_count = number1_values.Count(number => number > 0);
            while (true){ 
                int j = 0;
                while (j < numbers_per_row){
                    if (number1_values[n] > 0){
                        Console.Write(Program.Factorial_(number1_values[n]) + " ");                    
                        sw.Write(Program.Factorial_(number1_values[n]) + " ");                    
                        ++i; j++;}
                    if (i >= number_count){
                        break;}
                    ++n;}            
                if (i >= number_count) 
                    break;  
                Console.WriteLine();                                  
                sw.WriteLine();}
            sw.Close();}
    
        // Функція запису файл "total.txt" елементів файлу "number2.txt", вирівняних по правому краї та елементів файлу "text2.txt", вирівняних по центрі
        public static void Total_Fill (string file1_ = "total.txt", string file2_ = "number2.txt", string file3_ = "text2.txt"){        
            StreamWriter sw = new StreamWriter(file1_);
            StreamReader sr1 = File.OpenText(file2_);
            StreamReader sr2 = File.OpenText(file3_);
            var lines_ = new List<string>();                                        
            lines_.Add(sr1.ReadLine());                    
            for (int i = 0; i < File.ReadLines(file3_).Count(); ++i){
                string line_ = sr2.ReadLine();                            
                lines_.Add(line_);}
            int max_length = 0;            
            for (int i = 0; i < lines_.Count(); ++i) 
                if (lines_[i].Count() > max_length) 
                    max_length = lines_[i].Count();                    
            for (int i = 0; i < lines_.Count(); ++i){                                
                if (i == 0){                                             
                    Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", max_length - lines_[0].Count()))}{lines_[0]}");                    
                    sw.Write($"{String.Concat(Enumerable.Repeat(" ", max_length - lines_[0].Count()))}{lines_[0]}");                    
                    continue;}
                int line_length = (max_length - lines_[i].Count())/2;
                sw.Write($"\n{String.Concat(Enumerable.Repeat(" ", line_length))}{lines_[i]}");
                Console.WriteLine($"{String.Concat(Enumerable.Repeat(" ", line_length))}{lines_[i]}");}            
            sr1.Close();
            sr2.Close();                
            sw.Close();}}
    class Program{
        public static void Main(){            
            // Console.OutputEncoding = System.Text.Encoding.Unicode;
            // Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.Clear();
            Random rand = new Random();
            int number_count = 12, numbers_per_row = rand.Next(1, 10);                                 
            bool f = false;
            while (!f){
                Console.Write(">> Чисел у файлі [1:oo]: ");
                f = int.TryParse(Console.ReadLine(), out number_count);
                if (number_count >=1 && f) 
                    break;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("    >> Невірний тип даних");
                Console.ResetColor();}
            if (numbers_per_row > number_count) 
                numbers_per_row = number_count;                

            // Заповнення файла "number1.txt"
            Console.WriteLine("\n>> Файл number1.txt:\n");
            File_.File_RandFill("number1.txt", number_count, numbers_per_row);

            // Заповнення файла "text2.txt"            
            File_.Remove_Line("text1.txt", "text2.txt");
            // Запис усіх елементів "number1.txt" до списку 
            var number1_values = new List<int>();
            StreamReader sr = File.OpenText("number1.txt");
            for (int j = 0; j < File.ReadLines("number1.txt").Count(); ++j){
                string[] line_ = sr.ReadLine().Split(" ");
                for (int i = 0; i < line_.Count()-1; ++i)                                            
                    number1_values.Add(Convert.ToInt32(line_[i]));}
            sr.Close();

            // Заповнення файла "number3.txt"
            Console.WriteLine("\n\n>> Файл number3.txt:\n");
            File_.Write_Factorial("number3.txt", number1_values, numbers_per_row);

            // До файлу "number2.txt" записується кількість позитивних елементів
            Console.WriteLine("\n\n>> Файл number2.txt:");
            StreamWriter sw = new StreamWriter("number2.txt");  
            sw.Write($"Result = {number1_values.Count(number => number > 0)}");
            Console.WriteLine($"\nResult = {number1_values.Count(number => number > 0)}");
            sw.Close();

            // Заповнення файла "total.txt"
            Console.WriteLine("\n>> файл total.txt:\n");
            File_.Total_Fill();
            // Перейменування файла "total.txt" на довільне ім'я
            Console.Write("\n>> Нове ім'я файла total.txt: ");
            string file_rename = Console.ReadLine();
            File.Move("total.txt", file_rename + ".txt");
            Console.WriteLine($"\n>> Файл total.txt перейменовано [{file_rename}.txt]\n");}
            
        // Функція підрахування факторіала
        public static int Factorial_(int number, int factorial = 1){            
            for (int i = 1; i < number + 1; ++i) 
                factorial *= i;
            return factorial;}}}