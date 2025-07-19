using UnityEngine;
using UnityEngine.UI;

public class HandSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button slotButton;
    private RuntimeCard heldCard;

    public void Initialise()
    {
        slotButton.onClick.AddListener(ShowOptions);
        this.gameObject.SetActive(false);
    }

    private void ShowOptions()
    {
        Debug.Log("Menu shown");
    }

    public void FillSlot(RuntimeCard card, Sprite card_sprite)
    {
        this.gameObject.SetActive(true);
        heldCard = card;
        icon.sprite = card_sprite;
    }

    public void EmptySlot()
    {
        icon.sprite = null;
        heldCard = null;
        this.gameObject.SetActive(false);
    }
}
