using System.Collections.Generic;
using JustPoChess.Client.Model.Entities.Board;

namespace JustPoChess.View.Input
{
    public class Input
    {
        public Input()
        {
        }

        public Move GetUserInput()
        {
            /*Don't forget exceptions
            Possible moves: 
            -A2-A4
            -resign
            -draw (offering - other player has to accept - display drawOffer msg to the other player)
            -new game - human/ai*/
            throw new System.NotImplementedException();
        }

        public List<Move> GeneratePossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBoard(Move move)
        {
            throw new System.NotImplementedException();
        }

        public GameState CheckIfGameStillActive()
        {
            throw new System.NotImplementedException();
        }
    }
}
