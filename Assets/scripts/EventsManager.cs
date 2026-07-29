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

        #region on game over
        public delegate void OnGameOver();
        public static OnStartGame onGameOver;
        public static void GameOver()
        {
            if (onGameOver != null)
            {
                onGameOver?.Invoke();
            }
        }
        #endregion
        #region btn play click
        public delegate void OnBtnPlayClick();
        public static OnBtnPlayClick onBtnPlayClick;
        public static void BtnPlayClick()
        {
            if (onBtnPlayClick != null)
            {
                onBtnPlayClick?.Invoke();
            }
        }
        #endregion
        #region btn play again click
        public delegate void OnBtnPlayAgainClick();
        public static OnBtnPlayClick onBtnPlayAgainClick;
        public static void BtnPlayAgainClick()
        {
            if (onBtnPlayAgainClick != null)
            {
                onBtnPlayAgainClick?.Invoke();
            }
        }
        #endregion
        #region score matches
        public delegate void OnMatch();
        public static OnBtnPlayClick onMatch;
        public static void Match()
        {
            if (onMatch != null)
            {
                onMatch?.Invoke();
            }
        }
        #endregion
        #region score mismatches
        public delegate void OnMisMatch();
        public static OnBtnPlayClick onMisMatch;
        public static void MisMatch()
        {
            if (onMisMatch != null)
            {
                onMisMatch?.Invoke();
            }
        }
        #endregion

    }


}

