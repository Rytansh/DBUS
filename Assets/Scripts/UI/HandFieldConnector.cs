using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class HandFieldConnector : MonoBehaviour
{
    // TODO: Card isn't properly removed from hand yet when placed.
    // Remove this script, and relocate these functions to a more appropriate location.
    public Menu cardHandClickedMenu;
    private PlayerHandUI playerHandUI;
    private PlayerFieldUI playerFieldUI;
    private Player player;
    public void Initialise(Player player, PlayerHandUI playerHandUI, PlayerFieldUI playerFieldUI)
    {
        this.playerFieldUI = playerFieldUI;
        this.playerHandUI = playerHandUI;
        this.player = player;
    }

    public void ShowCardHandClickedMenu(RuntimeCard card)
    {
        List<MenuOption> options = new List<MenuOption>
        {
            new MenuOption("Place Card", () => BeginCardPlacement(card)),
            new MenuOption("Card Details", () => OpenCardDetails(card)),
            new MenuOption("Cancel", () => cardHandClickedMenu.Hide())
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
                if (slot.gameObject.transform.childCount > 0) { continue; }
                slot.EnableSlotClick(async () => await PlaceCardInSlot(card, slot));
            }
        }
        else if (card.card_type == CardType.Skill)
        {
            foreach (FieldSlotUI slot in playerFieldUI.GetSkillSlots())
            {
                if (slot.gameObject.transform.childCount > 0) { continue; }
                slot.EnableSlotClick(async () => await PlaceCardInSlot(card, slot));
            }
        }

    }

    private async Task PlaceCardInSlot(RuntimeCard card, FieldSlotUI slot)
    {
        Debug.Log($"Placing {card.full_data.name} in {slot.GetSlotType()} slot {slot.GetIndex()}");
        if (slot.gameObject.transform.childCount > 0) { return; }
        await LoadCardPrefab(card);
        GameObject placedCard = Instantiate(card.card_prefab, slot.transform);
        placedCard.GetComponent<ClickableCard>().Initialise(card, player);
        foreach (FieldSlotUI s in playerFieldUI.GetCharacterSlots())
        {
            s.DisableSlotClick();
        }
        foreach (FieldSlotUI s in playerFieldUI.GetSkillSlots())
        {
            s.DisableSlotClick();
        }
        Debug.Log("Card placed.");
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
