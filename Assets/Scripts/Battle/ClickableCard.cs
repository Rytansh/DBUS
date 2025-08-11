using UnityEngine;
using DBUS.Events.Gameplay.Cards;

public class ClickableCard : MonoBehaviour
{
    private RuntimeCard card;
    private Player owner;

    public void Initialise(RuntimeCard card, Player owner)
    {
        this.card = card;
        this.owner = owner;
    }

    void OnMouseDown()
    {
        EventBus.Instance.Broadcast(new CardClickedEvent{ card = this.card, owner = this.owner});
    }
}
