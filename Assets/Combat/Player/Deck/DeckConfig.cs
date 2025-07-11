using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DeckConfig", menuName = "Deck/Configuration")]
public class DeckConfig : ScriptableObject
{
    [Header("Drop cards here to form the player deck - testing purposes only")]
    [SerializeField] private List<CardSO> editorDeck = new List<CardSO>();

    [Header("IDs are generated automatically from items in the editor deck")]
    [SerializeField] private List<string> cardIDs = new List<string>();
    public List<string> GetCardIDs() => cardIDs;

    private void OnValidate()
    {
        cardIDs.Clear();
        foreach (CardSO card in editorDeck)
        {
            if (card != null && !cardIDs.Contains(card.GetID()))
                cardIDs.Add(card.GetID());
        }
    }
}

