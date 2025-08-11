using UnityEngine;
using DBUS.Events.Gameplay.Attacks;
using DBUS.Events.Gameplay.Cards;
public class AttackTargetingSystem
{
    private RuntimeCard attacker;
    private Player attackerOwner;

    public delegate void OnTargetSelectedHandler(RuntimeCard attacker, RuntimeCard target);
    public event OnTargetSelectedHandler OnTargetSelected;

    public AttackTargetingSystem()
    {
        EventBus.Instance.Subscribe<TargetingAttackEvent>(SelectTarget);
        EventBus.Instance.Subscribe<CardClickedEvent>(AttemptAttack);
    }

    void SelectTarget(TargetingAttackEvent evt)
    {
        attacker = evt.card;
        attackerOwner = evt.owner;
        Debug.Log("Targeting mode started: Select a card to attack.");
    }

    void AttemptAttack(CardClickedEvent evt)
    {
        if (attacker == null) return;

        if (evt.owner == attackerOwner)
        {
            Debug.LogWarning("You cannot target your own card.");
            attacker = null;
            return;
        }
        else
        {
            OnTargetSelected?.Invoke(attacker, evt.card);
        }

        attacker = null; 
    }
}
