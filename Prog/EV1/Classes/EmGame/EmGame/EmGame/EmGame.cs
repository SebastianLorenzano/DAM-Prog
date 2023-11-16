using Classes;
using System;
using static UDK.IFont;
using UDK;

namespace EmGame
{

    public class EmGame : UDK.IGameDelegate
    {
        private int _frameCount;
        private int hasWonText;

        //public TeamType GetWinner()
        //{
        //    return TeamType.HUMAN;
        //}

        WarZone warzone = new WarZone();
        public void OnLoad(GameDelegateEvent gameEvent)
        {
            warzone.CreateAllWarriors(150, 150);
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {

        }

        public void OnAnimate(GameDelegateEvent gameEvent)
        {
            _frameCount++;
            if (_frameCount > 50 && warzone.AreAllTeamsRemaining())
            {
                warzone.ExecuteRound();
                _frameCount = 0;
            }
            if (!warzone.AreAllTeamsRemaining() && hasWonText == 0)
            {
                Console.WriteLine(warzone.GetWarriorList()[0].GetTeam() + "  Has Won.");
                hasWonText++;
            }


        }

        public void OnDraw(GameDelegateEvent gameEvent, ICanvas canvas)
        {

            {
                canvas.Clear(0, 0, 0, 1);
                warzone.DrawAll(canvas);

            }

        }

        public void OnUnload(GameDelegateEvent gameEvent)
        {

        }
    }
    }


