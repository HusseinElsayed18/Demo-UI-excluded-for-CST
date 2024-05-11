using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace CST
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [HideInInspector] public SoundsManager soundsManager;
        [HideInInspector] public CardsManager cardsManager;
        [HideInInspector] public UIManager uIManager;
        [HideInInspector] public ScoreManager scoreManager;
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
                scoreManager = GetComponent<ScoreManager>();
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

        public bool CreateFile(string filenameWithextension, string data)
        {
            try
            {
                string path = Application.persistentDataPath + filenameWithextension;

                if (!File.Exists(path))
                {
                    File.WriteAllText(path, data, System.Text.Encoding.UTF8);
                    return true;
                }
                else
                {
                    File.WriteAllText(path, data, System.Text.Encoding.UTF8);
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogMsg(" createFile() // " + filenameWithextension + ex.Message);
            }
            return false;
        }
        public string ReadFile(string filenameWithextension)
        {
            try
            {
                string path = Application.persistentDataPath + filenameWithextension;
                if (!File.Exists(path))
                {
                    return JsonUtility.ToJson(new ScoreManager.Score());
                }
                else
                {

                    return File.ReadAllText(path);
                }
            }
            catch (Exception ex)
            {
                LogMsg(" readFile() // " + filenameWithextension + ex.Message);
            }
            return "";
        }

    }

    public static class AnimateUIYAxis
    {
        public static List<RectTransform> UIs = new List<RectTransform>();
      public static IEnumerator AnimateBtnYAxis(float sec, RectTransform btn, float oldY, float targetY)
        {
            if (UIs.Contains(btn))
            {
                yield return new WaitUntil(() => UIs.Contains(btn) == false);
            }
            UIs.Add(btn);
            btn.GetComponent<Button>().interactable = false;
            float calculatedTime = 0;
            if (oldY > 0 && targetY > 0)
            {
                calculatedTime = (sec / (targetY - oldY));
            }
            else if (oldY > 0 && targetY < 0)
            {
                calculatedTime = (sec / (oldY + (-1 * targetY)));
            }
            else if (oldY < 0 && targetY >= 0)
            {
                calculatedTime = (sec / (targetY + (-1 * oldY)));
            }


            float y = oldY;
            btn.localPosition = new Vector3(0, oldY, 0);
            if (oldY > targetY)
            {
                while (y > targetY)
                {
                    yield return new WaitForSeconds(calculatedTime);
                    y -= 10;
                    btn.localPosition = new Vector3(0, y, 0);
                }
            }
            else if (oldY < targetY)
            {
                while (y < targetY)
                {
                    yield return new WaitForSeconds(calculatedTime);
                    y += 10;
                    btn.localPosition = new Vector3(0, y, 0);
                }
            }

            btn.localPosition = new Vector3(0, targetY, 0);
            btn.GetComponent<Button>().interactable = true;
            UIs.Remove(btn);
        }
    }

}

