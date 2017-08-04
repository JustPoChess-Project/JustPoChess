using System;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.View.Input;

namespace JustPoChess.Client.MVC
{
    public class StartUp
    {
        public static void Main()
		{
            //General Program settings
            //Mandatory fuck Unix users
            Console.CursorVisible = false;
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                Controller.Controller.Start();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e);
            }
        }
    }
}
