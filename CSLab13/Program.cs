
using Terminal.Gui;
namespace CSLab13
{
    public partial class Program
    {
        // public List<string> ScoreBase = new List<string>();



        public static void Main()
        {
            Console.Clear();
            List<string> ScoreBase = new List<string>();
            Branch br = new Branch();
            
            ScoreBase.Add(br.StartGame());

            foreach (var inner in ScoreBase)
            {
                Console.WriteLine(inner);
            }

            // Application.Init();
            // Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            // Application.Run(new CSLab13.MyDialog());
            // Application.Shutdown();
        }
    }
}