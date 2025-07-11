using UnityEngine;

public class CardSO : ScriptableObject
{
    [SerializeField] private Sprite cardSprite;
    [SerializeField] private string cardID;
    [SerializeField] private GameObject cardPrefab;

    public Sprite GetSprite() { return cardSprite; }
    public string GetID() { return cardID; }
    public GameObject GetPrefab() { return cardPrefab; }

}
