using UnityEngine;
using System.Collections.Generic;
using DBUS.Events.Gameplay.Cards;
using DBUS.Events.Gameplay.Turns;
using DBUS.Events.Gameplay.Attacks;

public class AttackOptionsMenu
{
    private Player currentPlayer;
    private Player owner;
    private Menu attackOptionsMenu;
    public AttackOptionsMenu(Player owner, Menu attackOptionsMenu)
    {
        this.owner = owner;
        this.attackOptionsMenu = attackOptionsMenu;
        EventBus.Instance.Subscribe<TurnStartedEvent>(TrackPlayer);
        EventBus.Instance.Subscribe<CardClickedEvent>(OnCardClick);
    }

    void OnCardClick(CardClickedEvent evt)
    {
        if (currentPlayer != owner) { return; }
        if (currentPlayer != evt.owner) { return; }
        else
        {
            List<MenuOption> options = new List<MenuOption>
            {
                new MenuOption("Attack", () => EventBus.Instance.Broadcast(new TargetingAttackEvent{card = evt.card, owner = currentPlayer})),
                new MenuOption("Cancel", () => attackOptionsMenu.Hide())
            };
            Vector3 positionToShow = new Vector3(Input.mousePosition.x + 200, Input.mousePosition.y, Input.mousePosition.z);
            attackOptionsMenu.Show(positionToShow, options);
        }
    }

    void TrackPlayer(TurnStartedEvent evt)
    {
        currentPlayer = evt.player;
    }
}
