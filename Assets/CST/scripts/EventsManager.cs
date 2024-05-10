using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CST
{
    public static class EventsManager 
    {
        #region on start game
        public delegate void OnStartGame();
        public static OnStartGame onStartGame;
        public static void StartGame()
        {
            if (onStartGame != null)
            {
                onStartGame?.Invoke();
            }
        }
        #endregion
        #region btn click
        public delegate void OnBtnClick();
        public static OnBtnClick onBtnClick;
        public static void BtnClick()
        {
            if (onBtnClick != null)
            {
                onBtnClick?.Invoke();
            }
        }
        #endregion


    }


}

