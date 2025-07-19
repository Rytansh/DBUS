using System.Threading.Tasks;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerUI player1UI;
    //[SerializeField] private PlayerUI player2UI;

    [SerializeField] private EntityLoader entityLoaderP1;
    //[SerializeField] private EntityLoader entityLoaderP2;

    private Player player1;
    private Player player2;

    public async void StartBattleButton()
    {
        try { await StartBattle(); }
        catch (Exception ex) { Debug.LogError($"Battle failed to start: {ex}"); }
    }
    private async Task StartBattle()
    {
        PlayerInitData initDataP1 = new PlayerInitData
        {
            playerUI = player1UI,
            loader = entityLoaderP1
        };
        player1 = new Player();
        await player1.Initialise(initDataP1); 
    }

}

