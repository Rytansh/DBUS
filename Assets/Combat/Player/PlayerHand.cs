using System.Collections.Generic;
public class PlayerHand
{
    private CardSO[] currentHand;
    public void Initialise()
    {
        currentHand = new CardSO[4];
    }

    public bool CheckForAvailableSlots()
    {
        foreach (CardSO card in currentHand) { if (card == null) return true; }
        return false;
    }

    public void PlaceCardInHand(CardSO cardToPlace) // places a designated card in the first available slot
    {
        if (!CheckForAvailableSlots()) return;
        for (int i = 0; i < currentHand.Length; i++)
        {
            if (currentHand[i] != null) { continue; }
            else { currentHand[i] = cardToPlace; return; }
        }
    }
    
    public IReadOnlyList<CardSO> GetPlayerHand() => currentHand;

}
