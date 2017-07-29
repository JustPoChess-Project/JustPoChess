using System;
using System.Media;
using JustPoChess.Client.MVC.OSChecker;

namespace JustPoChess.Client.MVC.View.Sounds
{
    public static class SoundEffects
    {
        private static readonly SoundPlayer Player = new SoundPlayer();

        public static void PlaySelectionSound()
        {
            if (CheckOS.IsLinux)
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

        public static void PlayTraverseSound()
        {
            if (CheckOS.IsLinux)
            {
                Player.SoundLocation = "../../Sounds/Sounds/Traverse.wav";
                Player.Play();
            }
            else
            {
                Player.SoundLocation = @"..\..\Sounds\Sounds\Traverse.wav";
                Player.Play();
            }
        }

        public static void Stop()
        {
            Player.Stop();
        }
    }
}