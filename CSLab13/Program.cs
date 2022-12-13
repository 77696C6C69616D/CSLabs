using Terminal.Gui;
namespace CSLab13
{
    public partial class Program
    {
        public static void Main () { 
            // Console.Clear();
            // Код програми розділен між двома файлами:
            // Gui.cs - інтерфейс (графіки)
            Gui gui = new Gui(); 
            // Branch.cs - додаткові функції
            Branch br = new Branch();

            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute (Color.Green, Color.Black);
            Application.Run(new CSLab13.MyDialog());
            Application.Shutdown();


        }
    }
}