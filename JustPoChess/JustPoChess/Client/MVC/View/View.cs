using System;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Menu;

namespace JustPoChess.Client.MVC.View
{
    public static class View
    {
        public static void InitialScreen()
        {
            Menu.LinuxMenu.InitialScreen();
        }

        public static void InitializeMenu()
        {
            Menu.LinuxMenu.InitializeMenu();
        }

        public static void StopMusic()
        {
            //Sounds.OST.Stop();
        }

        public static void PrintBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{8 - x} ");
                for (int y = 0; y < 8; y++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (Model.Model.GetBoardState()[x, y] == null)
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
                        Console.Write($"{GetPieceString(Model.Model.GetBoardState(), x, y)}");
                    }
                }
                Console.WriteLine();
                if (x == 7)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  a b c d  e f g h");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }

		//testing purposes
		public static void PrintTestBoard()
		{
			for (int x = 0; x < 8; x++)
			{
				Console.Write($"{8 - x} ");
				for (int y = 0; y < 8; y++)
				{
					if (Model.Model.GetTestBoardState()[x, y] == null)
					{
						if ((x + y) % 2 != 0)
						{
							Console.Write("■ ");
						}
						else
						{
							Console.Write("■ ");
						}
					}
					else
					{
					    Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"{GetPieceString(Model.Model.GetTestBoardState(), x, y)} ");
					}
				}
				Console.WriteLine();
				if (x == 7)
				{
					Console.WriteLine("  a  b  c  d   e  f  g  h");
				    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
			}
		}

        public static void MirrorPrintBoard()
        {
            var mirroredBoard = new IPiece[8, 8];

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    mirroredBoard[x, y] = Model.Model.GetBoardState()[7 - x, 7 - y];
                }
            }

            for (int x = 0; x < 8; x++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{x + 1} ");
                for (int y = 0; y < 8; y++)
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
                Console.WriteLine();
                if (x == 7)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  h g f e  d c b a");
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