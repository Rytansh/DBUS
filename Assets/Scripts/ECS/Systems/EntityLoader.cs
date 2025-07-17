using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Unity.Entities;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json;

public class EntityLoader : MonoBehaviour
{
    [SerializeField] private string[] characterAddresses; // e.g. "C2_Krillin"

    public async Task<List<RuntimeCard>> LoadAllCards()
    {
        List<Task<RuntimeCard>> loadTasks = new List<Task<RuntimeCard>>();

        foreach (string address in characterAddresses)
        {
            loadTasks.Add(LoadCardAsync(address));
        }

        RuntimeCard[] results = await Task.WhenAll(loadTasks);
        return new List<RuntimeCard>(results);
    }

    private async Task<RuntimeCard> LoadCardAsync(string address)
    {
        AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(address); //loads the file at the address into a handle of type operation
        await handle.Task;

        if (handle.Status != AsyncOperationStatus.Succeeded) { Debug.LogError("Failed to load JSON: " + address); return null; }

        CardData data = JsonConvert.DeserializeObject<CardData>(handle.Result.text); //deserialises the handle into card data

        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entity entity = Entity.Null; //define an empty entity

        switch (data.cardtype)
        {
            case CardType.Character:
                if (data.character_exclusive_data == null) { Debug.LogWarning("No character data specified."); }
                EntityArchetype characterArchetype = entityManager.CreateArchetype(typeof(CharacterStatsComponent));
                entity = entityManager.CreateEntity(characterArchetype);

                CharacterStatsComponent characterStats = new CharacterStatsComponent
                {
                    attack = data.stats.attack,
                    defense = data.stats.defense,
                    health = data.stats.health,
                };

                entityManager.SetComponentData(entity, characterStats);
                Debug.Log($"Spawned {data.character_exclusive_data.battletype} {data.cardtype}, {data.character_exclusive_data.rarity} state {data.name} with stats: Attack {characterStats.attack}, Defense {characterStats.defense}, Health: {characterStats.health}");
                break;

            case CardType.Skill:
                EntityArchetype skillArchetype = entityManager.CreateArchetype(typeof(SkillStatsComponent));
                entity = entityManager.CreateEntity(skillArchetype);

                SkillStatsComponent skillStats = new SkillStatsComponent
                {
                    duration = data.skill_exclusive_data.duration,
                };

                entityManager.SetComponentData(entity, skillStats);
                Debug.Log($"Spawned {data.cardtype}, {data.skill_exclusive_data.rarity} state {data.name} with duration {skillStats.duration} turns.");
                break;

            default:
                Debug.LogWarning($"Unknown card type: {data.cardtype}");
                break;
        }
        return new RuntimeCard
        {
            id = data.id,
            card_type = data.cardtype,
            full_data = data,
            card_entity = entity
        };
    }

}

