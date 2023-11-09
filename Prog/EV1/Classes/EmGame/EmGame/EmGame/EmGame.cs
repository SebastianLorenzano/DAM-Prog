using Classes;
using System;
using static UDK.IFont;
using UDK;

namespace EmGame
{
    public class EmGame : UDK.IGameDelegate
    {
        private int _frameCount;
        

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
            _frameCount++;
            if (_frameCount > 100 && warzone.AreAllTeamsRemaining() == true)
            {
                warzone.ExecuteRound();

            }


        }

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {

            {
                canvas.Clear(0, 0, 0, 1);
                warzone.DrawAll(canvas);
                _frameCount = 0;
            }

        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
    }


