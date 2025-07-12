using UnityEngine;
using System.Collections.Generic;

public class PlayerHandUI : MonoBehaviour
{
    [SerializeField] private HandSlotUI[] handSlots = new HandSlotUI[4];

    public void Initialise()
    {
        foreach (HandSlotUI handSlot in handSlots)
        {
            handSlot.Initialise();
        }
    }

    public void RefreshSlotsUI(IReadOnlyList<CardSO> currentHand)
    {
        for (int i = 0; i < handSlots.Length; i++)
        {
            if (currentHand[i] == null) { handSlots[i].EmptySlot(); }
            else { handSlots[i].FillSlot(currentHand[i]); }
        }
    }
}
