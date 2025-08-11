using UnityEngine;
using Unity.Entities;

public class RuntimeCard
{
    public Player owner;
    public string id;
    public Sprite card_sprite;
    public GameObject card_prefab;
    public CardType card_type;
    public Entity card_entity;
    public CardData full_data; 
    
}
