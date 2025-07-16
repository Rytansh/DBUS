using UnityEngine;
using System.Collections.Generic;

public class PlayerDeck
{
    // private CardDatabase cardDatabase;
    // private List<CardSO> deck;


    // public void Initialise(DeckConfig deckConfig, CardDatabase cardDatabase)
    // {
    //     this.deckConfig = deckConfig;
    //     this.cardDatabase = cardDatabase;
    //     deck = new List<CardSO>();
    //     if (deckConfig.GetCardIDs() == null || deckConfig.GetCardIDs().Count == 0) {Debug.LogWarning("Deck not instantiated or empty. Please instantiate or fill before trying to access elements from it."); return;}
    //     foreach (string id in deckConfig.GetCardIDs())
    //     {
    //         if (cardDatabase == null) { Debug.LogWarning("Card Database not instantiated. Please instantiate before trying to access elements from it."); return; }
    //         if (cardDatabase.GetCardByID(id) == null) { continue; }
    //         deck.Add(cardDatabase.GetCardByID(id));
    //     }
    // }

    // public CardSO DrawAndRemoveRandomCard()
    // {
    //     if (!HasCards()) return null;
    //     int indexToRemove = Random.Range(0, deck.Count);
    //     CardSO returnedCard = deck[indexToRemove];
    //     deck.RemoveAt(indexToRemove);
    //     return returnedCard;
    // }

    // public bool HasCards()
    // {
    //     if (deck.Count == 0) return false;
    //     return true;
    // }

    //public IReadOnlyList<CardSO> GetPlayerDeck() => deck.AsReadOnly();
}
