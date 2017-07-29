using System.Media;
using JustPoChess.Client.MVC.OSChecker;

namespace JustPoChess.Client.MVC.View.Sounds
{
    public static class OST
    {        
        private static readonly SoundPlayer Player = new SoundPlayer();
        
        public static void PlayInitialScreenOST()
        {
            if (CheckOS.IsLinux)
            {
                Player.SoundLocation = "../../Sounds/OST/InitialScreenOST.wav";
                Player.Play();
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\OST\InitialScreenOST.wav";
                Player.Play();
            }
        }

        public static void Stop()
        {
            Player.Stop();
        }
        
    }
}
