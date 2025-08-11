using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerHandUI playerhandUI;
    [SerializeField] private PlayerFieldUI playerfieldUI;
    [SerializeField] private HandFieldConnector handFieldConnector;

    [SerializeField] private Menu attackOptionsMenu;

    private TurnViewController turnViewController;
    private AttackOptionsMenu attackOptionsController;
    

    public void Initialise(Player player)
    {
        playerhandUI.Initialise(handFieldConnector);
        playerfieldUI.Initialise();
        handFieldConnector.Initialise(player, playerhandUI, playerfieldUI);
        attackOptionsController = new AttackOptionsMenu(player, attackOptionsMenu);
    }

    public PlayerHandUI GetPlayerHandUI() { return playerhandUI; }
}
