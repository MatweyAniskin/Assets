using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<Card> allCards = new List<Card>();
    
    List<Card> cardsInArm = new List<Card>();
    List<Card> unusedCard = new List<Card>();

    public void SetCards(List<Card> cards)
    {
        unusedCard = allCards = cards;
        cardsInArm.Clear(); 
    }
    public Card ShiftUnusedCardToArm()
    {
        if (unusedCard.Count == 0)
            return null;
        Card temp = unusedCard[Random.Range(0, unusedCard.Count)];
        unusedCard.Remove(temp);
        cardsInArm.Add(temp);
        return temp;
    }
    public void RemoveCardInArm(int i) => RemoveCardInArm(cardsInArm[i]);
    public void RemoveCardInArm(Card card)
    {
        unusedCard.Add(card);
        cardsInArm.Remove(card);
    }
    public Card[] CurCards => cardsInArm.ToArray();
    public int UnusedCardsCount => unusedCard.Count;
}