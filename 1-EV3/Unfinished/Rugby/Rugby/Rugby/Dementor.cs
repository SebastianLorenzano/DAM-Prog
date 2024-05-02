namespace Rugby
{
    public class Dementor : Character
    {



        public Dementor()
        {
            x = -10;
            y = -10;
        }





        public override void ExecuteTurn(Stadium stadium)
        {
            throw new NotImplementedException();
        }

        public void MoveToStartingPosition(Stadium stadium)
        {
            while (true)
            {
                int newX = Utils.GetRandomInt(0, stadium.Width);
                int newY = Utils.GetRandomInt(0, stadium.Height);
                if (stadium.GetCharacterAt(newX, newY) == null)
                {
                    x = newX;
                    y = newY;
                    break;
                }
            }
        }

    }
}
