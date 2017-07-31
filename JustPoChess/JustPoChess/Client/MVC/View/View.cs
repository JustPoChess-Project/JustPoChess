using System;
using System.Linq;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;
using JustPoChess.Client.MVC.View.Art;
using JustPoChess.Client.MVC.View.Font;

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
            Fontinator.SetConsoleFont();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int x = 0; x < 8; x++)
            {
                Console.Write($"{8 - x}  ");
                for (int y = 0; y < 8; y++)
                {

                    if (Board.BoardState[x, y] == null)
                    {
                        if ((x + y) % 2 != 0)
                        {
                            Console.Write("■\u2009");
                        }
                        else
                        {
                            Console.Write("▢\u2009");
                        }
                    }
                    else
                    {
                        Console.Write($"{GetPieceString(Board.BoardState, x, y)} ");
                    }
                }
                Console.WriteLine();
                if (x == 7)
                {
                    Console.WriteLine();
                    Console.WriteLine("   A \u2009B \u2009C \u2009D \u2009E \u2009F \u2009G \u2009H");
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