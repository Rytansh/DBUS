using UnityEngine;
using UnityEngine.UI;

public class HandSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button slotButton;
    private CardSO heldCard;

    public void Initialise()
    {
        slotButton.onClick.AddListener(ShowOptions);
        this.gameObject.SetActive(false);
    }

    private void ShowOptions()
    {
        Debug.Log("Menu shown");
    }

    public void FillSlot(CardSO card)
    {
        this.gameObject.SetActive(true);
        heldCard = card;
        icon.sprite = card.GetSprite();
    }

    public void EmptySlot()
    {
        icon.sprite = null;
        heldCard = null;
        this.gameObject.SetActive(false);
    }
}
