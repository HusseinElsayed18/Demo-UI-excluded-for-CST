using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CST
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [HideInInspector] public SoundsManager soundsManager;
        [HideInInspector] public CardsManager cardsManager;
        [HideInInspector] public UIManager uIManager;
        private void Awake()
        {
            if (Instance != null)
            {
                LogMsg("there is an error");
            }
            else
            {
                Instance = this;
                soundsManager = GetComponent<SoundsManager>();
                cardsManager = GetComponent<CardsManager>();
                uIManager = GetComponent<UIManager>();
            }
        }

        private void Start()
        {
           
        }

        [System.Diagnostics.Conditional("ENABLE_LOG")]
        public static void LogMsg(object msg)
        {
            Debug.Log(msg);
        }

        
    }

    
}

