using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CardController : MonoBehaviour
{
    [SerializeField] Deck deck;
    [SerializeField] Stats stats;

    public void UseCards(List<Card> cards) => cards.ForEach(i => deck.RemoveCardInArm(i));    
    public int CurEnergy => stats.CurEnergy;
    public int MaxEnergy => stats.MaxEnergy;
    public Card[] CurCards => deck.CurCards;
    public abstract void StartMove();   
}
