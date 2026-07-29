using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CST
{
    [System.Serializable]
    public struct Card
    {
        public Sprite card;
    }
    public class CardsManager : MonoBehaviour
    {
        UIManager uIManager;
        const int minSize = 2, maxSize = 8;
        public  int rows, cols;
        [SerializeField] Cards cardsScriptableObj;
        Cards boardCards;
        public List<Button> cardItems = new List<Button>();
        public Button selectedCard = null;
        private void Awake()
        {
            uIManager = GameManager.Instance.uIManager;
            InitCards();
            EventsManager.onBtnPlayClick += ()=> { InitBoardCards();  StartCoroutine(FlipCards(cardItems, 1f)); } ;
            EventsManager.onBtnPlayAgainClick += () => { InitBoardCards();  StartCoroutine(FlipCards(cardItems, 1f)); };
        }
        private void Start()
        {
           
        }

       //void  Update()
       // {
       //     if (Input.GetKeyDown(KeyCode.Space))
       //     {
       //         InitBoardCards();
       //         StartCoroutine(FlipCards(cardItems, 1f));
       //     }
       // }

        IEnumerator FlipCards(List<Button> cardItems , float sec)
        {
            yield return new WaitForSeconds(sec);

            for (int i = 0; i < cardItems.Count; i++)
            {
                cardItems[i].transform.GetChild(0).GetComponent<Image>().sprite = uIManager.cardLockImg;
            }
            selectedCard = null;
        }

        void InitBoardCards()
        {
            cardItems.Clear();
            InitBoardCardsSize();
          
            FillBoardCards();
            PoolingBoardCards(rows * cols, uIManager.cardItemPrefab, uIManager.matchingBoardPools , uIManager.matchingBoard);
            InstantiateCards(uIManager.cardItemPrefab,uIManager.matchingBoard);
        }
        void InitBoardCardsSize()
        {
            rows = Random.Range(minSize, maxSize);
            cols = Random.Range(minSize, maxSize);
            if ((rows * cols) % 2 != 0)
            {
                InitBoardCardsSize();
            }
        }
        void InitCards()
        {
            boardCards = (Cards)ScriptableObject.CreateInstance("Cards");
            boardCards.cards = new List<Card>();

        }
        void FillBoardCards()
        {
            boardCards.cards.Clear();
            for (int i = 0; i < (rows * cols) / 2; i++)
            {
                boardCards.cards.Add(cardsScriptableObj.cards[Random.Range(0, cardsScriptableObj.cards.Count)]);
            }
        }
        void PoolingBoardCards( int size ,Button item , RectTransform matchingBoardPools , RectTransform matchingBoard)
        {
            int matchingBoardCardsSize = matchingBoard.childCount;
            if (matchingBoardCardsSize > 0)
            {
                for(int i = 0; i < matchingBoardCardsSize ; i++)
                {
                    Transform card = matchingBoard.GetChild(0);
                    card.GetComponent<Button>().enabled = true;
                    card.GetComponent<Image>().enabled = true;
                    card.SetParent(matchingBoardPools);
                    
                }
            }

            int pools = matchingBoardPools.childCount;
            if ( size > pools)
            {
                for(int i = 0; i < (size-pools); i++)
                {
                    Instantiate(item, matchingBoardPools).GetComponent<CardBtn>().cardsManager = this;
                }
               
            }
        }
       
        void InstantiateCards( Button item, RectTransform board )
        {
            float x = board.sizeDelta.x;
            float y = board.sizeDelta.y;
            board.GetComponent<GridLayoutGroup>().cellSize = new Vector2( x / cols , y / rows );

            for (int i = 0; i < boardCards.cards.Count ; i++)
            {
                InstantiateCard(item, board, boardCards.cards[i]);
                InstantiateCard(item, board, boardCards.cards[i]);
            }
            RandomCards(cardItems);
            DisableTransparentCardItems();
            
        }
       void InstantiateCard(Button item, RectTransform board , Card card )
        {
            Button cardItem =  uIManager.matchingBoardPools.GetChild(0).GetComponent<Button>();
            cardItem.transform.SetParent(board);
            cardItems.Add(cardItem);
            cardItem.GetComponent<CardBtn>().card = card;
            cardItem.transform.GetChild(0).GetComponent<Image>().sprite = card.card;
            cardItem.enabled = true;
            cardItem.GetComponent<Image>().enabled = true;
        }
        void RandomCards(List<Button> cardItems)
        {
            for (int i = 0; i < cardItems.Count; i++)
            {
                cardItems[i].transform.SetSiblingIndex (Random.Range(0, rows * cols) );
            }
        }
        void DisableTransparentCardItems()
        {

            for (int i = 0; i < cardItems.Count; i++)
            {
                if (cardItems[i].GetComponent<CardBtn>().card.card == uIManager.cardTransparentImg)
                {
                    Button card = cardItems[i];
                    DisableCardItem(card);
                    i = i - 1;
                }
            }

        }

        public void DisableCardItem(Button card)
        {
            cardItems.Remove(card);
            card.enabled = false;
            card.GetComponent<Image>().enabled = false;
            card.transform.GetChild(0).GetComponent<Image>().sprite = uIManager.cardTransparentImg;
        }
     
    }
}

