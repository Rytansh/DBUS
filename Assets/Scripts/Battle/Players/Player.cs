using UnityEngine;

public class Player
{
    private PlayerDeck playerDeck;
    private PlayerHand playerHand;
    private PlayerUI playerUI;

    public void Initialise(PlayerInitData data)
    {
        // playerDeck = new PlayerDeck();
        // playerDeck.Initialise(data.deckConfig, data.cardDatabase);

        // playerUI = data.playerUI;
        // playerUI.Initialise();

        // playerHand = new PlayerHand();
        // playerHand.Initialise();
        // FillPlayerHand();

        //foreach (CardSO card in playerDeck.GetPlayerDeck()) { Debug.Log("In Deck:" + card); }
    }

    public void FillPlayerHand()
    {
        // while (playerHand.CheckForAvailableSlots() && playerDeck.HasCards())
        // {
        //     //CardSO cardToPlace = playerDeck.DrawAndRemoveRandomCard();
        //     //if (cardToPlace == null) break;
        //     //playerHand.PlaceCardInHand(cardToPlace);
        // }
        // playerUI.GetPlayerHandUI().RefreshSlotsUI(playerHand.GetPlayerHand());
    }
}
