using UnityEngine;
using DBUS.Events.Turns;

public class TurnSystem : MonoBehaviour
{

    //NOTE: This should become a non-monobehaviour class in the future, as the startnewturn method will be called automatically rather than using a button.
    private Player player1;
    private Player player2;

    private Player currentTurnPlayer;
    public void Initialise(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        currentTurnPlayer = player1;
        EventBus.Instance.Broadcast(new TurnStartedEvent { player=currentTurnPlayer });
    }

    public void StartNewTurn()
    {
        EventBus.Instance.Broadcast(new TurnEndedEvent { player=currentTurnPlayer });
        currentTurnPlayer = currentTurnPlayer == player1 ? player2 : player1;
        EventBus.Instance.Broadcast(new TurnStartedEvent { player=currentTurnPlayer });
    }
}
