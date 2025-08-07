using UnityEngine;
using UnityEngine.UI;

public class HandSlotUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Button slotButton;
    private HandFieldConnector handFieldConnector;
    private RuntimeCard heldCard;


    public void Initialise(HandFieldConnector handFieldConnector)
    {
        this.handFieldConnector = handFieldConnector;
        slotButton.onClick.AddListener(ShowOptions);
        this.gameObject.SetActive(false);
    }

    private void ShowOptions()
    {
        if (heldCard == null || handFieldConnector == null) { return; }
        handFieldConnector.ShowCardHandClickedMenu(heldCard);
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
