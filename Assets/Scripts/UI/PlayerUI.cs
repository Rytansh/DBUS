using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerHandUI playerhandUI;

    public PlayerHandUI GetPlayerHandUI() { return playerhandUI; }

    public void Initialise()
    {
        playerhandUI.Initialise();
    }
}
