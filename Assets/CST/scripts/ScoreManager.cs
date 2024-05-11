using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CST
{
    public class ScoreManager : MonoBehaviour
    {
        [System.Serializable]
        public struct Score
        {
            [SerializeField] public int matches ;
            [SerializeField] public int turns;
        }
        [SerializeField] public Score score = new Score();
        const string savedSysFileName = "player.sav";
        private void Awake()
        {
            EventsManager.onStartGame += () => { LoadSys(savedSysFileName);
            };
            EventsManager.onMatch += Match;
            EventsManager.onMisMatch += Turns;
            EventsManager.onGameOver += GameOver;
        }

        void Match()
        {
            score.matches += 1;
            GameManager.Instance.uIManager.matchesNum.text = "" + score.matches;
        }
        void Turns()
        {
            score.turns += 1;
            GameManager.Instance.uIManager.turnsNum.text = "" + score.turns;
        }
        bool SavingSys(string file , Score score)
        {
            Score old = LoadSys(savedSysFileName);
            Score newScore = new Score();
            newScore.matches = old.matches + score.matches;
            newScore.turns = old.turns + score.turns;
   
            string json =  JsonUtility.ToJson(newScore);
            if (GameManager.Instance.CreateFile(savedSysFileName, json))
            {
                return true;
            }
            return false;
        }
        Score LoadSys(string file)
        {
            string json = GameManager.Instance.ReadFile(file);
            Score score = JsonUtility.FromJson<Score>(json);
            GameManager.Instance.uIManager.matchesNumSys.text = "" + score.matches;
            GameManager.Instance.uIManager.turnsNumSys.text = "" + score.turns;
            return score;
        }
        void GameOver()
        {
            SavingSys(savedSysFileName, score);
            LoadSys(savedSysFileName);
            score.matches = 0;
            score.turns = 0;
            GameManager.Instance.uIManager.matchesNum.text = "" + score.matches;
            GameManager.Instance.uIManager.turnsNum.text = "" + score.turns;
            
        }
    }
}

