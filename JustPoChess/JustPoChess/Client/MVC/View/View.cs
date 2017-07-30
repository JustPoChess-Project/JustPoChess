using System;
using System.Linq;
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
                for (int y = 0; y < 8; y++)
                {

                    if (Board.BoardState[x, y] == null)
                    {
                    }
                    else
                    {
                        
                    }
                }

                Console.WriteLine();
                if (x == 7)
                {
                    Console.WriteLine("  A B C D E F G H");
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