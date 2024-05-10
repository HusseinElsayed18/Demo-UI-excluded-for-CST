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
        const int minSize = 2, maxSize = 6;
        public  int rows, cols;
        [SerializeField] Cards cardsScriptableObj;
        public Cards boardCards;
       public List<Button> cardItems = new List<Button>();
        private void Awake()
        {
           
        }
        private void Start()
        {
            InitBoardCards();
        }
        void InitBoardCards()
        {
            InitBoardCardsSize();
            if ((rows * cols) % 2 != 0)
            {
                InitBoardCardsSize();
            }
            InitCards();
            InstantiateCards(GameManager.Instance.uIManager.cardItemPrefab,GameManager.Instance.uIManager.matchingBoard);
        }
        void InitBoardCardsSize()
        {
            rows = Random.Range(minSize, maxSize);
            cols = Random.Range(minSize, maxSize);
           
        }
        void InitCards()
        {
            boardCards = (Cards)ScriptableObject.CreateInstance("Cards");
            boardCards.cards = new List<Card>();
            for (int i = 0; i < (rows * cols) / 2; i++)
            {
                boardCards.cards.Add(cardsScriptableObj.cards[Random.Range(0, cardsScriptableObj.cards.Count)]);
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
        }
       void InstantiateCard(Button item, RectTransform board , Card card )
        {
            Button cardItem = Instantiate(item, board);
            cardItems.Add(cardItem);
            cardItem.GetComponent<CardBtn>().card = card;
            cardItem.transform.GetChild(0).GetComponent<Image>().sprite = card.card;
        }
        void RandomCards(List<Button> cardItems)
        {
            for (int i = 0; i < rows * cols; i++)
            {
                cardItems[i].transform.SetSiblingIndex (Random.Range(0, rows * cols) );
            }
        }
    }
}

