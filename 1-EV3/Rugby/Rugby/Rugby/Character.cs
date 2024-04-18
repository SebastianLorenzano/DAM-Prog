namespace Rugby
{


    public abstract class Entity
    {
        public int x, y;
    }
    

    public abstract class Character : Entity
    {

        public abstract void ExecuteTurn();


    }
}
