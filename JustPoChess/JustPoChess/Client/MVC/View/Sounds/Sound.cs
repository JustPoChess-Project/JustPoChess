using System;
using System.Configuration;
using System.Media;

namespace JustPoChess.Client.MVC.View.Sounds
{
    public static class Sound
    {
        private static readonly SoundPlayer Player = new SoundPlayer();

        public static void PlayInitialScreenOST()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsUnix"]))
            {
                Player.SoundLocation = @"../../Sounds/OST/InitialScreenOST.wav";
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\OST\InitialScreenOST.wav";
            }

            Player.Play();
        }

        public static void PlayMenuOST()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsUnix"]))
            {
                Player.SoundLocation = @"../../Sounds/OST/MenuOST.wav";
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\OST\MenuOST.wav";
            }

            Player.Play();
        }

        public static void PlaySelectionSound()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsUnix"]))
            {
                Player.SoundLocation = @"../../Sounds/SoundEffects/selection.wav";
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\SoundEffects\selection.wav";
            }

            Player.Play();
        }

        public static void PlayTraverseSound()
        {
            if (bool.Parse(ConfigurationManager.AppSettings["IsUnix"]))
            {
                Player.SoundLocation = @"../../Sounds/SoundEffects/traverse.wav";
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\SoundEffects\traverse.wav";
            }

            Player.Play();
        }

        public static void Stop()
        {
            Player.Stop();
        }
    }
}
  