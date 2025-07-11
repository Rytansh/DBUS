using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardDatabase", menuName = "Card/Database")]
public class CardDatabase : ScriptableObject
{
    [SerializeField] private List<CardSO> allCards;
    private Dictionary<string, CardSO> cardLookup;

    public void Initialise()
    {
        PopulateDictionary();
    }

    public CardSO GetCardByID(string id)
    {
        if (cardLookup == null) { return null; }
        if (cardLookup.TryGetValue(id, out CardSO card)) return card;

        Debug.LogWarning($"Card with ID {id} not found in database.");
        return null;
    }

    private void PopulateDictionary()
    {
        cardLookup = new Dictionary<string, CardSO>();
        foreach (CardSO card in allCards)
        {
            string id = card.GetID();
            if (cardLookup.ContainsKey(id)) { continue; }
            cardLookup.Add(id, card);
        }
    }
}
