using Terminal.Gui;
using NStack;

namespace CSLab13
{
    class Gui
    {
        public void InitGui()
        {

            Application.Init();

            var top = Application.Top;
            var win = new Window("Test")
            {
                X = 0,
                Y = 0, // for menu
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(win);

            win.Add(

            //constrols

            );

            Application.Run();
            Application.Shutdown();
        }
    }
}