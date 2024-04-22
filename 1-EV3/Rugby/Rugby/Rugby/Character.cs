namespace Rugby
{


    public abstract class Entity
    {
        public int x, y;

        public virtual Position GetPosition()
        {
            return new Position() { x = x, y = y };
        }


    }
    

    public abstract class Character : Entity
    {

        public abstract void ExecuteTurn(Stadium stadium);


    }
}
