using UnityEngine;

public class Player
{
    private PlayerDeck playerDeck;
    private PlayerHand playerHand;

    public void Initialise(PlayerInitData data)
    {
        playerDeck = new PlayerDeck();
        playerDeck.Initialise(data.deckConfig, data.cardDatabase);

        playerHand = new PlayerHand();
        playerHand.Initialise();
        FillPlayerHand();

        foreach (CardSO card in playerDeck.GetPlayerDeck()) { Debug.Log("In Deck:" + card); }
    }

    public void FillPlayerHand()
    {
        while (playerHand.CheckForAvailableSlots() && playerDeck.HasCards())
        {
            CardSO cardToPlace = playerDeck.DrawAndRemoveRandomCard();
            if (cardToPlace == null) break;
            playerHand.PlaceCardInHand(cardToPlace);
        }
        foreach (CardSO card in playerHand.GetPlayerHand()) { Debug.Log("In Hand:" + card); }
    }
}
