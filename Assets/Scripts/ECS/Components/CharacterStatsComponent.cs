using Unity.Entities;

public struct CharacterStatsComponent : IComponentData
{
    public int attack;
    public int defense;
    public int health;
}
