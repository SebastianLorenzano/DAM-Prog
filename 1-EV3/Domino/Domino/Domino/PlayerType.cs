
namespace Domino
{


    public class ImpulsivePlayer : Player
    {
        public ImpulsivePlayer(string name) : base(name)
        {

        }



        public override Piece? PickPieceToThrow(Juego juego)
        {
            List<Piece> result = GetPlayablePieces(juego);
            var doubles = GetDoublesSorted(result);
            if (doubles.Count > 0)
                return doubles[0];
            Utils.SortPieces(ref result);
            return result[0];  



        }


    }
}
