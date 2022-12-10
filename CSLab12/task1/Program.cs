// Завдання 1-2 
namespace CSLab12Task1
{
    class Dictionary { 
        public List<string> UaEngWordBase = new List<string>();
        public List<string> EngUaWordBase = new List<string>();
        // Список кількості слів в словникових базах
        public List<int> DicLen = new List<int>();
        // Функія заповнення списків (колекцій) даними з файлів (потребує трохи часу на обробку)
        public void FillWordBase () { 
            string eng_ua = $"../.dictionary/eng_ua.txt"; 
            string ua_eng = $"../.dictionary/ua_eng.txt"; 
            StreamReader sr = File.OpenText(eng_ua);
            Console.WriteLine("[Поповняється словникова база..]");
            for (int index = 0; index < File.ReadLines(eng_ua).Count(); index++)
            {
             EngUaWordBase.Add(sr.ReadLine());
            }
            DicLen.Add(File.ReadLines(eng_ua).Count());
            sr.Close();
            StreamReader rs = File.OpenText(ua_eng);
            for (int index = 0; index < File.ReadLines(ua_eng).Count(); index++)
            {
             UaEngWordBase.Add(rs.ReadLine());
            }  
            DicLen.Add(File.ReadLines(ua_eng).Count());
            rs.Close();
            Console.Clear();
        }
        // Функція перекладу (включаючи зміну напрямку перекладу)
        public void Dict () {
            string TranslateMode = "1"; 
            while (true) { 
                Console.WriteLine($"\n1:[укр-англ] \n2:[за замов.]:[англ-укр] \n3:[вихід]");
                Console.Write("[режим]: ");
                TranslateMode = Console.ReadLine();
                if (TranslateMode == "3") break;
                while (true) { 
                    Console.Write("\n> слово: ");
                    string word = Console.ReadLine();
                    if (word == "3") { Console.Clear(); break; };
                    if (TranslateMode == "1") { 
                        Console.WriteLine($"> переклад: {UaEng(word)}");
                        continue;
                    }
                    Console.WriteLine($"> переклад: {EngUa(word)}");
                }
            }
        }
        // Переклад з англійської на українську
        public string EngUa (string word) { 
            for (int index = 0; index < EngUaWordBase.Count(); index++)
            {
                if (EngUaWordBase[index].ToUpper() == word.ToUpper() && index % 2 == 0) { 
                    return EngUaWordBase[index + 1];
                    break;
                }
            }
            return "Слово не знайдено";
        }
        // Переклад з української на англійську
        public string UaEng (string word) { 
            for (int index = 0; index < UaEngWordBase.Count(); index++)
            {
                if (UaEngWordBase[index].ToUpper() == word.ToUpper() && index % 2 == 0) { 
                    return UaEngWordBase[index + 1];
                    break;
                }
            }
            return "Слово не знайдено";
        }
    }    
    class Program
    {
        public static void Main () { 
            Console.Clear();
            Dictionary dic = new Dictionary();
            // Заповнення словникової бази даними з файлів
            dic.FillWordBase();
            // Переклад із зміною напрямка
            dic.Dict();
        }
    }
}