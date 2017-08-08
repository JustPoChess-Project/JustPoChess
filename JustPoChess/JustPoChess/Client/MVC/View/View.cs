using System;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.OSChecker;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Menu;
using JustPoChess.Client.MVC.View.Sounds;

namespace JustPoChess.Client.MVC.View
{
    public class View
    {
        private static WindowsMenu windowsMenu = WindowsMenu.Instance;
        private static LinuxMenu linuxMenu = LinuxMenu.Instance;
        private static View instance;
        
        private static Model.Model model = MVC.Model.Model.Instance;

        private View()
        {
        }

        public static View Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new View();
                }
                return instance;
            }
        }
        public static Model.Model Model
        {
            get { return model; }
            set { model = value; }
        }

        public static void InitialScreen()
        {
            if (CheckOS.IsLinux)
            {
                linuxMenu.InitialScreen();
            }
            else
            {
                windowsMenu.InitialScreen();
            }
        }

        public static void InitializeMenu()
        {
            if (CheckOS.IsLinux)
            {
                linuxMenu.InitializeMenu();
            }
            else
            {
                windowsMenu.InitializeMenu();
            }
        }

        public static void StopMusic()
        {
            Sound.Stop();
        }

        public static void PrintBoard()
        {
            for (int x = 0; x < Board.BoardSize; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{Board.BoardSize - x}| ");
                for (int y = 0; y < Board.BoardSize; y++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (Model.Board.BoardState[x, y] == null)
                    {
                        if ((x + y) % 2 != 0)
                        {
                            Console.Write(GameArt.BlackSquare + " ");
                        }
                        else
                        {
                            Console.Write(GameArt.WhiteSquare + " ");
                        }
                    }
                    else
                    {
                        Console.Write($"{GetPieceString(Model.Board.BoardState, x, y)} ");
                    }
                }
                Console.Write(Environment.NewLine);

                if (x == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"   ________________{Environment.NewLine}");
                    Console.Write($"   a b c d e f g h{Environment.NewLine}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }

        public static void MirrorPrintBoard()
        {
            var mirroredBoard = new IPiece[Board.BoardSize, Board.BoardSize];

            for (int x = 0; x < Board.BoardSize; x++)
            {
                for (int y = 0; y < Board.BoardSize; y++)
                {
                    mirroredBoard[x, y] = Model.Board.BoardState[Board.BoardSize - x - 1, Board.BoardSize - y - 1];
                }
            }

            for (int x = 0; x < Board.BoardSize; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{x + 1}| ");
                for (int y = 0; y < Board.BoardSize; y++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (mirroredBoard[x, y] == null)
                    {
                        if ((x + y) % 2 != 0)
                        {
                            Console.Write(GameArt.BlackSquare);
                        }
                        else
                        {
                            Console.Write(GameArt.WhiteSquare);
                        }
                    }
                    else
                    {
                        Console.Write($"{GetPieceString(mirroredBoard, x, y)}");
                    }
                }
                Console.Write(Environment.NewLine);
                if (x == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"   ________________{Environment.NewLine}");
                    Console.Write($"   h g f e d c b a{Environment.NewLine}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }

        private static string GetPieceString(IPiece[,] boardState, int x, int y)
        {
            switch (boardState[x, y].PieceType)
            {
                case PieceType.Bishop:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            return GameArt.BlackBishop;

                        case PieceColor.White:
                            return GameArt.WhiteBishop;
                    }
                    break;

                case PieceType.King:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            return GameArt.BlackKing;

                        case PieceColor.White:
                            return GameArt.WhiteKing;
                    }
                    break;

                case PieceType.Knight:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            return GameArt.BlackKnight;

                        case PieceColor.White:
                            return GameArt.WhiteKnight;
                    }
                    break;

                case PieceType.Pawn:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            return GameArt.BlackPawn;

                        case PieceColor.White:
                            return GameArt.WhitePawn;
                    }
                    break;

                case PieceType.Queen:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            return GameArt.BlackQueen;

                        case PieceColor.White:
                            return GameArt.WhiteQueen;
                    }
                    break;

                case PieceType.Rook:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            return GameArt.BlackRook;

                        case PieceColor.White:
                            return GameArt.WhiteRook;
                    }
                    break;
            }

            return string.Empty;
        }
    }
}