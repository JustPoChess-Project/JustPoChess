using System;

namespace JustPoChess.Client.MVC.View.Input
{
    public static class InputUtilities
    {
        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(false);
        }
    }
}
