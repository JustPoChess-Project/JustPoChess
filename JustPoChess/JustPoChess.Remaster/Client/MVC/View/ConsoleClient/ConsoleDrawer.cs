using System;
using JustPoChess.Remaster.Client.MVC.Model.Contracts;
using JustPoChess.Remaster.Client.MVC.Model.Enums;
using JustPoChess.Remaster.Client.MVC.Model.Utils;
using JustPoChess.Remaster.Client.MVC.View.Contracts;

namespace JustPoChess.Remaster.Client.MVC.View.ConsoleClient
{
    public class ConsoleDrawer:IDrawer
    {
        public void Draw(IBoard board)
        {
            for (int x = 0; x < Dimentions.BoardHeight; x++)
            {
                Console.Write($"{Dimentions.BoardHeight - x}| ");
                for (int y = 0; y < Dimentions.BoardWidth; y++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (board.State[x, y] == null)
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
                        Console.Write($"{GetPieceString(board.State, x, y)} ");

                    }
                }
                
                Console.WriteLine();
                
                if (x == Dimentions.BoardHeight - 1)
                {
                    Console.Write($"   ________________{Environment.NewLine}");
                    Console.Write($"   a b c d e f g h{Environment.NewLine}");
                }
            }
        }

        private string GetPieceString(IPiece[,] boardState, int x, int y)
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