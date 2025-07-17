using System.Collections.Generic;
public class PlayerHand
{
    private RuntimeCard[] currentHand;

    public void Initialise()
    {
        currentHand = new RuntimeCard[4];
    }

    public bool CheckForAvailableSlots()
    {
        foreach (RuntimeCard card in currentHand) { if (card == null) return true; }
        return false;
    }

    public void PlaceCardInHand(RuntimeCard cardToPlace) // places a designated card in the first available slot
    {
        if (!CheckForAvailableSlots()) return;
        for (int i = 0; i < currentHand.Length; i++)
        {
            if (currentHand[i] != null) { continue; }
            else { currentHand[i] = cardToPlace; return; }
        }
    }

    public IReadOnlyList<RuntimeCard> GetPlayerHand() => currentHand;

}
