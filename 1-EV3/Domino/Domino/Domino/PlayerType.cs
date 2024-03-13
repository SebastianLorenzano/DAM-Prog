
namespace Domino
{


    public class ImpulsivePlayer : Player1
    {
        public ImpulsivePlayer(string name) : base(name)
        {

        }



        public override Piece? PickPieceToThrow(Game game)
        {
            if (game.PieceCount == 0)
            {
                var result1 = GetDoubles();
                if (result1.Count > 0)
                    Utils.SortPiecesByFirstValue(ref result1);
                else
                    result1 = _playerPieces;
                return result1[0];
            }
                
            var result = GetPlayablePieces(game);
            Utils.SortPiecesByFirstValue(ref result);
            var doubles = GetDoubles(result);
            if (doubles.Count > 0) 
                return doubles[0];
            if (result.Count > 0) 
                return result[0];  
            return null;
        }
    }
}
