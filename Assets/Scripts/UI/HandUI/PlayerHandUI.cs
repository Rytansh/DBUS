using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PlayerHandUI : MonoBehaviour
{
    [SerializeField] private HandSlotUI[] handSlots;

    public void Initialise(HandFieldConnector handFieldConnector)
    {
        foreach (HandSlotUI handSlot in handSlots)
        {
            handSlot.Initialise(handFieldConnector);
        }
    }

    public async Task RefreshSlotsUI(IReadOnlyList<RuntimeCard> currentHand)
    {
        await LoadSpritesInHand(currentHand);
        for (int i = 0; i < handSlots.Length; i++)
        {
            if (currentHand[i] == null) { handSlots[i].EmptySlot(); }
            else { handSlots[i].FillSlot(currentHand[i], currentHand[i].card_sprite); }
        }
    }

    public async Task LoadSpritesInHand(IReadOnlyList<RuntimeCard> hand)
    {
        List<Task> loadTasks = new();

        foreach (RuntimeCard card in hand)
        {
            if (card == null || card.card_sprite != null) continue;

            loadTasks.Add(LoadCardSprite(card));
        }

        await Task.WhenAll(loadTasks);
    }

    private async Task LoadCardSprite(RuntimeCard card)
    {
        if (string.IsNullOrEmpty(card.full_data.sprite_address)) return;

        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(card.full_data.sprite_address);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            card.card_sprite = handle.Result;
        }
        else
        {
            Debug.LogError($"Failed to load sprite for {card.full_data.name}");
        }
    }
}
