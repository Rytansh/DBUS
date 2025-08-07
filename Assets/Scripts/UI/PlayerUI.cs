using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerHandUI playerhandUI;
    [SerializeField] private PlayerFieldUI playerfieldUI;
    [SerializeField] private HandFieldConnector handFieldConnector;

    private TurnViewController turnViewController;

    public void Initialise()
    {
        playerhandUI.Initialise(handFieldConnector);
        playerfieldUI.Initialise();
        handFieldConnector.Initialise(playerhandUI, playerfieldUI);
    }

    public PlayerHandUI GetPlayerHandUI() { return playerhandUI; }
}
