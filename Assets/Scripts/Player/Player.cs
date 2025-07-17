using System.Threading.Tasks;
using UnityEngine;

public class Player
{
    private PlayerDeck playerDeck;
    private PlayerHand playerHand;
    private PlayerUI playerUI;

    public async Task Initialise(EntityLoader loader)
    {
        playerDeck = new PlayerDeck();
        await playerDeck.Initialise(loader);

        playerHand = new PlayerHand();
        playerHand.Initialise();
        FillPlayerHand();
    }

    public void FillPlayerHand()
    {
        if(playerHand == null || playerDeck == null) { return; }
        while (playerHand.CheckForAvailableSlots() && playerDeck.HasCards())
        {
            RuntimeCard cardToPlace = playerDeck.DrawAndRemoveRandomCard();
            if (cardToPlace == null) break;
            playerHand.PlaceCardInHand(cardToPlace);
        }
        foreach (RuntimeCard card in playerHand.GetPlayerHand())
        {
            if (card == null) { continue; }
            if (card.full_data == null) { Debug.Log("Null card data"); continue; }
            Debug.Log(card.full_data.name);
        }
    }
}
