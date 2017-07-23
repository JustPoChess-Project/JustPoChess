using System.Media;

namespace JustPoChess.Client.View
{
    public static class Sounds
    {
        private static SoundPlayer player = new SoundPlayer();

        public static void PlayInitialScreenOST()
        {
            player.SoundLocation = @"..\..\Sounds\OST\InitialScreenOST.wav";
            player.Play();
        }

        public static void PlaySelectionSound()
        {
            player.SoundLocation = @"..\..\Sounds\Sounds\selection.wav";
            player.Play();
        }

        public static void Stop()
        {
            player.Stop();
        }
    }
}
