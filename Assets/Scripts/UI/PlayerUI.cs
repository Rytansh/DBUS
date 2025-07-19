using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerHandUI playerhandUI;

    public void Initialise()
    {
        playerhandUI.Initialise();
    }

    public PlayerHandUI GetPlayerHandUI() { return playerhandUI; }
}
