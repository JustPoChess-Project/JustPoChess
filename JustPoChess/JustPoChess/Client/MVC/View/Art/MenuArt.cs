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

        public static readonly string HotSeatText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}HOT SEAT";

        public static readonly string OnlineText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}ONLINE";

        public static readonly string VersusAiText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}VERSUS AI";

        public static readonly string AiVersusAiText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}AI VERSUS AI";

        public static readonly string SpectateText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}SPECTATE";

        public static readonly string ExitText = $"{new string(' ', Console.LargestWindowWidth / 2 - 12)}EXIT";
    }
}
