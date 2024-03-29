﻿using Classes;
using System;
using static UDK.IFont;
using UDK;

namespace EmGame
{

    public class EmGame : UDK.IGameDelegate
    {
        private int _frameCount;
        private int hasWonText;


        WarZone warzone = new WarZone();
        public void OnLoad(GameDelegateEvent gameEvent)
        {
            warzone.CreateAllWarriors(500, 500);   // En modo release en mi pc se aguanta hasta 700 x 700, pero asegurarse de ponerlo en modo Release.
        }

        public void OnKeyboard(GameDelegateEvent gameEvent, IKeyboard keyboard, IMouse mouse)
        {

        }

        public void OnAnimate(GameDelegateEvent gameEvent)
        {
            _frameCount++;
            if (_frameCount > 1 && warzone.AreAllTeamsRemaining())
            {
                warzone.ExecuteRound();
                _frameCount = 0;
            }
            if (!warzone.AreAllTeamsRemaining() && hasWonText == 0)
            {
                if (warzone.GetWarriorAt(0) != null)
                { 
                    Console.WriteLine(warzone.GetWarriorAt(0).GetTeam() + "  Has Won.");
                }
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


