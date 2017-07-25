using System;
using JustPoChess.Client.Model.Entities.Board;
using JustPoChess.Client.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC
{
    public class View
    {
       public View(Model model)
       {
           //ToDo:
       }
         
        //Player specific
        public void PrintBoard()
        {
            
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (Board.BoardState[x, y] == null)
                    {
                        Console.Write(' ');
                    }
                    else if (Board.BoardState[x, y].PieceType == PieceType.Bishop)
                    {
                        if (Board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('B');
                        }
                        else
                        {
                            Console.Write('b');
                        }
                    }
                    else if (Board.BoardState[x, y].PieceType == PieceType.King)
                    {
                        if (Board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('K');
                        }
                        else
                        {
                            Console.Write('k');
                        }
                    }
                    else if (Board.BoardState[x, y].PieceType == PieceType.Knight)
                    {
                        if (Board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('H');
                        }
                        else
                        {
                            Console.Write('h');
                        }
                    }
                    else if (Board.BoardState[x, y].PieceType == PieceType.Pawn)
                    {
                        if (Board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('P');
                        }
                        else
                        {
                            Console.Write('p');
                        }
                    }
                    else if (Board.BoardState[x, y].PieceType == PieceType.Queen)
                    {
                        if (Board.BoardState[x, y].PieceColor == PieceColor.White)
                        {
                            Console.Write('Q');
                        }
                        else
                        {
                            Console.Write('q');
                        }
                    }
                    else if (Board.BoardState[x, y].PieceType == PieceType.Rook)
                    {
                        if (Board.BoardState[x, y].PieceColor == PieceColor.White)
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
