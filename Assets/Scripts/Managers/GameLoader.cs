using System.Threading.Tasks;
using UnityEngine;
using System;
using Cinemachine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PlayerUI player1UI;
    [SerializeField] private PlayerUI player2UI;

    [SerializeField] private CinemachineVirtualCamera p1camera;
    [SerializeField] private CinemachineVirtualCamera p2camera;

    [SerializeField] private Canvas p1canvas;
    [SerializeField] private Canvas p2canvas;

    [SerializeField] private EntityLoader entityLoaderP1;
    [SerializeField] private EntityLoader entityLoaderP2;

    private Player player1;
    private Player player2;
    private TurnViewController turnViewController;
    private BattleSystem battleSystem;
    [SerializeField] TurnSystem turnSystem;

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
            loader = entityLoaderP1,
            UICanvas = p1canvas,
            camera = p1camera
        };
        player1 = new Player();
        await player1.Initialise(initDataP1);
        PlayerInitData initDataP2 = new PlayerInitData
        {
            playerUI = player2UI,
            loader = entityLoaderP2,
            UICanvas = p2canvas,
            camera = p2camera
        };
        player2 = new Player();
        await player2.Initialise(initDataP2);

        PlayerView player1View = new PlayerView{
            camera = p1camera,
            canvas = p1canvas
        };
        PlayerView player2View = new PlayerView{
            camera = p2camera,
            canvas = p2canvas
        };
        turnViewController = new TurnViewController(player1, player2, player1View, player2View);
        battleSystem = new BattleSystem(player1, player2, turnSystem);
    }

}

