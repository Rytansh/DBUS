using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayerDeck
{
    private List<RuntimeCard> deck;

    public async Task Initialise(EntityLoader loader)
    {
        List<RuntimeCard> loadedCards = await loader.LoadAllCards();
        deck = new List<RuntimeCard>(loadedCards);
    }

    public RuntimeCard DrawAndRemoveRandomCard()
    {
        if (!HasCards()) return null;
        int indexToRemove = Random.Range(0, deck.Count);
        RuntimeCard returnedCard = deck[indexToRemove];
        deck.RemoveAt(indexToRemove);
        return returnedCard;
    }

    public bool HasCards()
    {
        if (deck.Count == 0) return false;
        return true;
    }

    public IReadOnlyList<RuntimeCard> GetPlayerDeck() => deck.AsReadOnly();
    public int GetCardCount() => deck.Count;
}
