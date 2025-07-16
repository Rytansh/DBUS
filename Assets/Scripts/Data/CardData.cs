using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardType
{
    Character,
    Skill
}

[JsonConverter(typeof(StringEnumConverter))]
public enum BattleType
{
    Powerful,
    Magical,
    Tactical,
    Flexible
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Speciality
{
    Assassination,
    Annihilation,
    Detonation,
    Protection,
    Acceleration,
    Rejuvenation,
    Corrosion,
    Disruption,
    Condemnation,
    Manipulation
}

[JsonConverter(typeof(StringEnumConverter))]
public enum CharacterRarity
{
    Normal,
    Rare,
    Special,
    Ultimate,
    PRIME_Ultimate,
    TRICHIC
}

[JsonConverter(typeof(StringEnumConverter))]
public enum SkillRarity
{
    Normal,
    Rare,
    Super,
    Ultimate,
    PRIME_Ultimate
}

[System.Serializable]
public class Stats
{
    public int attack;
    public int defense;
    public int health;
}

[System.Serializable]
public class CardData
{
    public string id;
    public CardType cardtype;
    public string name;
    public BattleType battletype;
    public Speciality specialty;
    public Stats stats;
    public CharacterData character_exclusive_data;
    public SkillData skill_exclusive_data;
}

public class CharacterData
{
    public string battletype;
    public CharacterRarity rarity;
}

public class SkillData
{
    public int duration;
    public SkillRarity rarity;
}