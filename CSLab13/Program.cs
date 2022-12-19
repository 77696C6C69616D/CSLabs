
using Terminal.Gui;
namespace CSLab13
{
    public partial class Program
    {
        public static void Main()
        {
            Console.Clear();
            List<string> ScoreBase = new List<string>();
            Branch br = new Branch();
            // while (true) { 
            //     string tmp = (br.StartGame());    
            //     ScoreBase.Add(tmp);
            //     Console.WriteLine("\n" + tmp);        
            //     Console.Write("" +
            //     "\n![Продовжити? (1:так)]\n$ ");
            //     string inp = Convert.ToString(Console.ReadLine()); 
            //     if (inp != "1") { break; }
            // }
            // Console.Clear();


            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            Application.Run(new CSLab13.MyDialog());
            Application.Shutdown();
        }
    }
}