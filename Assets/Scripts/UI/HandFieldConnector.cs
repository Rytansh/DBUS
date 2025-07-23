using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class HandFieldConnector : MonoBehaviour
{
    public Menu cardHandClickedMenu;
    private PlayerHandUI playerHandUI;
    private PlayerFieldUI playerFieldUI;
    public void Initialise(PlayerHandUI playerHandUI, PlayerFieldUI playerFieldUI)
    {
        this.playerFieldUI = playerFieldUI;
        this.playerHandUI = playerHandUI;
    }

    public void ShowCardHandClickedMenu(RuntimeCard card)
    {
        List<MenuOption> options = new List<MenuOption>
        {
            new MenuOption("Place Card", () => BeginCardPlacement(card)),
            new MenuOption("Card Details", () => OpenCardDetails(card))
        };
        Vector3 positionToShow = new Vector3(Input.mousePosition.x - 200, Input.mousePosition.y, Input.mousePosition.z);
        cardHandClickedMenu.Show(positionToShow, options);
    }

    private void BeginCardPlacement(RuntimeCard card)
    {
        Debug.Log("Placing card...");
        if (playerFieldUI == null) { return; }
        if (card.card_type == CardType.Character)
        {
            foreach (FieldSlotUI slot in playerFieldUI.GetCharacterSlots())
            {
                slot.EnableSlotClick(async () => await PlaceCardInSlot(card, slot));
            }
        }
        else if (card.card_type == CardType.Skill)
        {
            foreach (FieldSlotUI slot in playerFieldUI.GetSkillSlots())
            {
                slot.EnableSlotClick(async () => await PlaceCardInSlot(card, slot));
            }
        }

    }

    private async Task PlaceCardInSlot(RuntimeCard card, FieldSlotUI slot)
    {
        Debug.Log($"Placing {card.full_data.name} in {slot.GetSlotType()} slot {slot.GetIndex()}");
        await LoadCardPrefab(card);
        Instantiate(card.card_prefab, slot.transform);
    }

    private void OpenCardDetails(RuntimeCard card)
    {
        Debug.Log("Opening card details...");
    }
    
    private async Task LoadCardPrefab(RuntimeCard card)
    {
        if (string.IsNullOrEmpty(card.full_data.prefab_address)) return;

        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(card.full_data.prefab_address);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            card.card_prefab = handle.Result;
        }
        else
        {
            Debug.LogError($"Failed to load prefab for {card.full_data.name}");
        }
    }
}
