using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerUI player1UI;
    [SerializeField] private PlayerUI player2UI;

    [SerializeField] private EntityLoader entityLoaderP1;
    [SerializeField] private EntityLoader entityLoaderP2;

    private Player player1;
    private Player player2;


    public void StartBattle()
    {
        player1 = new Player();
        player1.Initialise(entityLoaderP1);

        //player2 = new Player();
        //player2.Initialise(player2Data);

    }

}

