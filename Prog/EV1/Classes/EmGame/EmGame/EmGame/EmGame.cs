using Classes;
using System;
using static UDK.IFont;
using UDK;

namespace EmGame
{
    public class EmGame : UDK.IGameDelegate
    {

        

        //public TeamType GetWinner()
        //{
        //    return TeamType.HUMAN;
        //}

        WarZone warzone = new WarZone();
        public void OnLoad(GameDelegateEvent gameEvent)
        {
            warzone.CreateAllWarriors(50, 50);
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {

        }

        public void OnAnimate(GameDelegateEvent gameEvent)
        {
                warzone.ExecuteRound();

        }

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {
            canvas.Clear(1,1,1,1);
            warzone.DrawAll(canvas);
        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
    }


