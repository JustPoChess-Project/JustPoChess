using System;
using System.Windows.Media;

namespace JustPoChess.Client.MVC.View.Sounds
{
    public static class SoundEffects
    {
        private static readonly MediaPlayer Player = new MediaPlayer();

        public static void PlaySelectionSound()
        {
            Player.Open(new Uri(@"..\..\Sounds\SoundEffects\selection.wav", UriKind.Relative));
            Player.Play();
        }

        public static void PlayTraverseSound()
        {
            Player.Open(new Uri(@"..\..\Sounds\SoundEffects\traverse.wav", UriKind.Relative));
            Player.Play();
        }

        public static void Stop()
        {
            Player.Stop();
        }
    }
}