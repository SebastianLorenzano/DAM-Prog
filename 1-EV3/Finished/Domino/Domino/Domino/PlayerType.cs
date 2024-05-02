
namespace Domino
{


    public class ConservativePlayer : Player
    {
        public ConservativePlayer(string name) : base(name)
        {

        }

        public override Piece? PickPieceToThrow(Game game)
        {
            if (game.PieceCount == 0)
            {
                var result1 = GetDoubles();
                if (result1.Count == 0)
                    result1 = _playerPieces.ToList();

                Utils.SortPiecesByFirstValue(ref result1);
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

        public class ImpulsivePlayer : Player
        {
            public ImpulsivePlayer(string name) : base(name)
            {

            }

            public override Piece? PickPieceToThrow(Game game)
            {
                if (game.PieceCount == 0)
                {
                    var result1 = _playerPieces.ToList();
                    return DominoDeck.GetPiecesSortedByHighestValue(result1)[0];
                }

                var result = GetPlayablePieces(game);
                result = DominoDeck.GetPiecesSortedByHighestValue(result);
                if (result.Count > 0)
                    return result[0];
                return null;
            }
        }
    }
}
