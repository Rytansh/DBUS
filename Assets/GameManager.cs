using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DeckConfig p1DeckConfig;
    [SerializeField] private DeckConfig p2DeckConfig;
    [SerializeField] private CardDatabase cardDatabase;
    [SerializeField] private PlayerUI player1UI;
    [SerializeField] private PlayerUI player2UI;

    private Player player1;
    private Player player2;

    private Player currentTurn;

    public void StartBattle()
    {
        cardDatabase.Initialise();
        PlayerInitData player1Data = new PlayerInitData
        {
            deckConfig = p1DeckConfig,
            cardDatabase = cardDatabase,
            playerUI = player1UI
        };

        PlayerInitData player2Data = new PlayerInitData
        {
            deckConfig = p2DeckConfig,
            cardDatabase = cardDatabase,
            playerUI = player2UI
        };

        player1 = new Player();
        player1.Initialise(player1Data);

        player2 = new Player();
        //player2.Initialise(player2Data);

    }

}

