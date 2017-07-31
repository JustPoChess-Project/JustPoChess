using System;
using System.Linq;
using System.Threading;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.View.Art;

namespace JustPoChess.Client.MVC.View
{
    public class View
    {
        // public View(Model.Model model)
        // {
        //     //ToDo:
        // }

        //Player specific
        public void PrintBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{8 - x} ");
                for (int y = 0; y < 8; y++)
                {
                    if (Board.BoardState[x, y] == null)
                    {
                        if ((x + y) % 2 != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("■ ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("■ ");
                        }
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write($"{GetPieceString(Board.BoardState, x, y)} ");
                    }
                }
                Console.WriteLine();
                if (x == 7)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("  a  b  c  d   e  f  g  h");
                    Console.ResetColor();
                }
            }
        }

        public string GetPieceString(IPiece[,] boardState, int x, int y)
        {
            switch (boardState[x, y].PieceType)
            {
                case PieceType.Bishop:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.BlackBishop;

                        case PieceColor.White:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.WhiteBishop;
                    }
                    break;

                case PieceType.King:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.BlackKing;

                        case PieceColor.White:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.WhiteKing;
                    }
                    break;

                case PieceType.Knight:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.BlackKnight;

                        case PieceColor.White:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.WhiteKnight;
                    }
                    break;

                case PieceType.Pawn:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.BlackPawn;

                        case PieceColor.White:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.WhitePawn;
                    }
                    break;

                case PieceType.Queen:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.BlackQueen;

                        case PieceColor.White:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.WhiteQueen;
                    }
                    break;

                case PieceType.Rook:
                    switch (boardState[x, y].PieceColor)
                    {
                        case PieceColor.Black:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.BlackRook;

                        case PieceColor.White:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            return GameArt.WhiteRook;
                    }
                    break;
            }

            return string.Empty;
        }
    }
}