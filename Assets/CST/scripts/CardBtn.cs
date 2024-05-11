using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CST
{
    public class CardBtn : MonoBehaviour
    {
        public Card card;
        public CardsManager cardsManager;
        private void Awake()
        {
           
        }
       
        void Start()
        {
           

            GetComponent<Button>().onClick.AddListener(() => {
           
                transform.GetChild(0).GetComponent<Image>().sprite = card.card;
                if (cardsManager.selectedCard == null)
                {
                    cardsManager.selectedCard = GetComponent<Button>();
                }
                else
                {
                    if (cardsManager.selectedCard != GetComponent<Button>())
                    {
                        if (cardsManager.selectedCard.GetComponent<CardBtn>().card.card == card.card)
                        {                         
                            GameManager.Instance.soundsManager.MatchEffect();
                            StartCoroutine(MatchCards(0.2f));
                        }
                        else
                        {
                            GameManager.Instance.soundsManager.MisMatchEffect();
                            StartCoroutine(MisMatchCardsLock(0.2f));
                        }
                    }

                }
            });

        }
        IEnumerator MatchCards(float sec)
        {
            Button selectedCard = cardsManager.selectedCard;
            cardsManager.selectedCard = null;
            yield return new WaitForSeconds(sec);
            cardsManager.DisableCardItem(selectedCard);
            cardsManager.DisableCardItem(GetComponent<Button>());
            EventsManager.Match();
            if (cardsManager.cardItems.Count == 0)
            {
                EventsManager.GameOver();
            }
        }
        IEnumerator MisMatchCardsLock(float sec)
        {
            Button selectedCard = cardsManager.selectedCard;
            cardsManager.selectedCard = null;
            yield return new WaitForSeconds(sec);
            transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.uIManager.cardLockImg;
            selectedCard.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.uIManager.cardLockImg;
            EventsManager.MisMatch();
            
        }
        private void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
      
    }
}

