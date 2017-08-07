using System;

namespace JustPoChess.Client.MVC.View.Art
{
    public static class MenuArt
    {
        public static readonly string Continue = $"{new string(' ', Console.LargestWindowWidth / 2 - 14)}PRESS ANY KEY TO CONTINUE...";

        public static readonly string CopyrightLogo = $"{new string(' ', Console.LargestWindowWidth/ 2 - 11)}(c) 2017 CodeBenders";

        public static readonly string JustPoChessLogoUpper = $@"
{new string(' ', Console.LargestWindowWidth / 2 - 12)}♖ ♘ ♗ ♕ ♔ ♗ ♘ ♖
{new string(' ', Console.LargestWindowWidth / 2 - 12)}♙ ♙ ♙ ♙ ♙ ♙ ♙ ♙";
          
        public static readonly string JustPoChessLogoDown = $@"{new string(' ', Console.LargestWindowWidth / 2 - 12)}♟ ♟ ♟ ♟ ♟ ♟ ♟ ♟
{new string(' ', Console.LargestWindowWidth / 2 - 12)}♜ ♞ ♝ ♛ ♚ ♝ ♞ ♜";

        public static readonly string JustPoChessText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}------Just PoChess-----";
        public static readonly string JustPoChessMenu = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}----------Menu---------";
        public static readonly string JustPoChessPlay = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}----------Play---------";
        public static readonly string JustPoChessSpectate = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}-------Spectate--------";
        public static readonly string JustPoChessStartServer = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}------Start Server-----";

        public static readonly string PlayText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}PLAY";

        public static readonly string SpectateText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}SPECTATE";

        public static readonly string ExitText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}EXIT";

        public static readonly string BackText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}BACK";

        public static readonly string LocalText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}LOCAL";

        public static readonly string RemoteText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}REMOTE";

        public static readonly string AsHuman = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}AS HUMAN";

        public static readonly string AsAi = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}AS AI";

        public static readonly string StartServerText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}START SERVER";
    }
}
