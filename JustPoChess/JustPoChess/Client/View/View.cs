using System;
using JustPoChess.Client.Model.Entities.Board;
using JustPoChess.Client.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC
{
    public class View
    {
       // public View(Model model)
       // {
       //     //ToDo:
       // }

        //Player specific
        public void PrintBoard()
        {
            var board = new Board();
            board.InitBoard();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board.BoardState[x, y] == null)
                    {
                        Console.Write(' ');
                    }
                    else if (board.BoardState[x, y].PieceType == PieceType.Bishop)
                    {
                        if (board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('B');
                        }
                        else
                        {
                            Console.Write('b');
                        }
                    }
                    else if (board.BoardState[x, y].PieceType == PieceType.King)
                    {
                        if (board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('K');
                        }
                        else
                        {
                            Console.Write('k');
                        }
                    }
                    else if (board.BoardState[x, y].PieceType == PieceType.Knight)
                    {
                        if (board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('H');
                        }
                        else
                        {
                            Console.Write('h');
                        }
                    }
                    else if (board.BoardState[x, y].PieceType == PieceType.Pawn)
                    {
                        if (board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('P');
                        }
                        else
                        {
                            Console.Write('p');
                        }
                    }
                    else if (board.BoardState[x, y].PieceType == PieceType.Queen)
                    {
                        if (board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('Q');
                        }
                        else
                        {
                            Console.Write('q');
                        }
                    }
                    else if (board.BoardState[x, y].PieceType == PieceType.Rook)
                    {
                        if (board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('R');
                        }
                        else
                        {
                            Console.Write('r');
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
