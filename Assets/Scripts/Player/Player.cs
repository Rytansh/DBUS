using System.Threading.Tasks;
using UnityEngine;

public class Player
{
    private PlayerDeck playerDeck;
    private PlayerHand playerHand;
    private PlayerUI playerUI;

    public async Task Initialise(PlayerInitData loadedData)
    {
        playerUI = loadedData.playerUI;
        playerUI.Initialise();

        playerDeck = new PlayerDeck();
        await playerDeck.Initialise(loadedData.loader);

        playerHand = new PlayerHand();
        playerHand.Initialise();
        await FillPlayerHand();
    }

    public async Task FillPlayerHand()
    {
        if (playerHand == null || playerDeck == null) { return; }
        while (playerHand.CheckForAvailableSlots() && playerDeck.HasCards())
        {
            RuntimeCard cardToPlace = playerDeck.DrawAndRemoveRandomCard();
            if (cardToPlace == null) break;
            playerHand.PlaceCardInHand(cardToPlace);
        }
        await playerUI.GetPlayerHandUI().RefreshSlotsUI(playerHand.GetPlayerHand());
    }
}
