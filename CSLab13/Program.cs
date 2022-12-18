
using Terminal.Gui;
namespace CSLab13
{
    public partial class Program
    {
        public static void Main()
        {
            Branch br = new Branch();

            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            Application.Run(new CSLab13.MyDialog());
            Application.Shutdown();
        }
    }
}