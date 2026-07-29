using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CST
{
    public class UIManager : MonoBehaviour
    {
        #region background settings
        [Header("bg settings")]
        public GameObject bgPanel;
        #endregion
        #region play
        [Header("play panel")]
        public GameObject playPanel;
        public Button play;
        #endregion
        #region play again game over
        [Header("game over panel")]
        public GameObject gamrOverPanel;
        public Button playAgain;
        #endregion
        #region matching
        [Header("cards board")]
        public GameObject matchPanel;
        public RectTransform matchingBoard;
        public RectTransform matchingBoardPools;
        public Button cardItemPrefab;
        public Sprite cardLockImg , cardTransparentImg;
        public Text matchesNum, turnsNum;
        [Header("saved sys")]
        public Text matchesNumSys, turnsNumSys;
        #endregion

        private void Awake()
        {
            EventsManager.onStartGame += initGame;
            EventsManager.onGameOver += GameOver;
            EventsManager.onBtnPlayClick += PlayBtnClick;
            EventsManager.onBtnPlayAgainClick += PlayAgainBtnClick;
        }
        private void Start()
        {
            EventsManager.StartGame();
            play.onClick.AddListener(() => { EventsManager.BtnPlayClick(); });
            playAgain.onClick.AddListener(() => { EventsManager.BtnPlayAgainClick(); });
        }
        private void OnDestroy()
        {
            play.onClick.RemoveAllListeners();
        }
        void initGame()
        {
            bgPanel.SetActive(true);
            playPanel.SetActive(true);
            matchPanel.SetActive(false);
            gamrOverPanel.SetActive(false);
        }
        void GameOver()
        {
            bgPanel.SetActive(false);
            playPanel.SetActive(false);
            matchPanel.SetActive(false);
            gamrOverPanel.SetActive(true);
          
            StartCoroutine(AnimateUIYAxis.AnimateBtnYAxis(.4f , playAgain.GetComponent<RectTransform>() , Screen.height / 2 , -100));
            StartCoroutine(AnimateUIYAxis.AnimateBtnYAxis(.2f, playAgain.GetComponent<RectTransform>(), -100, 0));
        }
        void PlayBtnClick()
        {
            bgPanel.SetActive(true);
            playPanel.SetActive(false);
            matchPanel.SetActive(true);
            gamrOverPanel.SetActive(false);
        }
        void PlayAgainBtnClick()
        {
            bgPanel.SetActive(true);
            playPanel.SetActive(false);
            matchPanel.SetActive(true);
            gamrOverPanel.SetActive(false);
        }

    }


}

