using UnityEngine;

public enum CardType
{
    Character,
    Skill
}
[System.Serializable]
public class CharacterStats
{
    public int attack;
    public int defense;
    public int health;
}

[System.Serializable]
public class CharacterData
{
    public string id;
    public CardType cardtype;
    public string name;
    public string battletype;
    public string specialty;
    public string rarity;
    public CharacterStats stats;
}

