using System.Media;

namespace JustPoChess.Client.View
{
    public static class Sounds
    {
        private static readonly SoundPlayer Player = new SoundPlayer();

        public static void PlayInitialScreenOST()
        {
            Player.SoundLocation = @"..\..\Sounds\OST\InitialScreenOST.wav";
            Player.Play();
        }

        public static void PlaySelectionSound()
        {
            Player.SoundLocation = @"..\..\Sounds\Sounds\selection.wav";
            Player.Play();
        }

        public static void Stop()
        {
            Player.Stop();
        }
    }
}
