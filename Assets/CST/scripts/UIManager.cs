using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CST
{
    public class UIManager : MonoBehaviour
    {
        #region background settings
        public GameObject bgPanel;
        #endregion
        #region play
        public GameObject playPanel;
        public Button play;
        #endregion
        #region matching
        public GameObject matchPanel;
        public RectTransform matchingBoard;
        public Button cardItemPrefab;
        public Sprite cardLockImg;
        #endregion

        private void Awake()
        {
            EventsManager.onStartGame += initGame;
            EventsManager.onBtnClick += PlayBtnClick;
        }
        private void Start()
        {
            EventsManager.StartGame();
            play.onClick.AddListener(() => { EventsManager.BtnClick(); });
        }
        private void OnDestroy()
        {
            play.onClick.RemoveListener(() => { EventsManager.BtnClick(); });
        }
        void initGame()
        {
            bgPanel.SetActive(true);
            playPanel.SetActive(true);
            matchPanel.SetActive(false);
        }
        void PlayBtnClick()
        {
            bgPanel.SetActive(true);
            playPanel.SetActive(false);
            matchPanel.SetActive(true);
        }
    }


}

