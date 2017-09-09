using System;
using System.Collections.Generic;
using System.Linq;
using JustPoChess.Client.MVC.Model.Contracts;
using JustPoChess.Client.MVC.Model.Entities.Board;
using JustPoChess.Client.MVC.Model.Entities.Pieces.Abstract;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecePosition;
using JustPoChess.Client.MVC.Model.Entities.Pieces.PiecesEnums;

namespace JustPoChess.Client.MVC.Controller.Contracts
{
    public interface IController
    {
        void Start();
        bool IsMovePossible(IMove move);
        bool MoveDiscoversCheckToOwnKing(IMove move);

        bool PieceGivesCheckToOpponentsKing(IPiece piece);

        bool IsPieceProtected(IPiece piece);

        bool ValidatePosition(Position position);

        // Possible moves generator
        ICollection<IPosition> GenerateGuardedPositionsForPiece(IPiece piece);

        ICollection<IMove> GeneratePossibleMovesForPieceConsideringDiscoveringCheck(IPiece piece);

        ICollection<IMove> GeneratePossibleMovesForPieceWithoutConsideringDiscoveringCheck(IPiece piece);

        IEnumerable<IMove> GeneratePossibleMovesForPlayer(PieceColor pieceColor);

        // Player Check
        bool IsPlayerInCheck(PieceColor pieceColor);

        //Castle Checks
        bool IsCurrentPlayerLeftCastlePossible();

        bool IsCurrentPlayerRightCastlePossible();

        bool IsWhiteLeftCastlePossible();

        bool IsWhiteRightCastlePossible();

        bool IsBlackLeftCastlePossible();

        bool IsBlackRightCastlePossible();


        ICollection<IMove> GeneratePosslbeEnPassantMoves();

        bool CheckForCheckmate();

        bool CheckForDraw();
    }
}