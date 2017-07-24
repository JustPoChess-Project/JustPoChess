using System;
using System.Media;


namespace JustPoChess.Client.View
{
    public static class Sounds
    {
        
        private static readonly SoundPlayer Player = new SoundPlayer();

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }
        
        public static void PlayInitialScreenOST()
        {
            if (IsLinux)
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

        public static void PlaySelectionSound()
        {
            if (IsLinux)
            {
                Player.SoundLocation = "../../Sounds/Sounds/selection.wav";
                Player.Play();
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\Sounds\selection.wav";
                Player.Play();
            }
        }

        public static void Stop()
        {
            Player.Stop();
        }
        
    }
}
