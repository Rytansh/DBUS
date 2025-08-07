using UnityEngine;

public class BattleSystem
{
    private TurnSystem turnSystem;

    public BattleSystem(Player player1, Player player2, TurnSystem turnSystem)
    {
        this.turnSystem = turnSystem;
        this.turnSystem.Initialise(player1, player2);
    }
}
