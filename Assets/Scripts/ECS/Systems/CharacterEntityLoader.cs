using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Unity.Entities;
using Unity.Collections;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json;

public class EntityLoader : MonoBehaviour
{
    [SerializeField] private string characterJsonAddress; // e.g. "C2_Krillin"

    private async void Start()
    {
        await LoadCharacterAsync(characterJsonAddress);
    }

    private async Task LoadCharacterAsync(string address)
    {
        // 1. Load the JSON string using Addressables
        AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(address);
        await handle.Task;

        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("Failed to load JSON: " + address);
            return;
        }

        // 2. Deserialize JSON into a CharacterData object
        CharacterData data = JsonConvert.DeserializeObject<CharacterData>(handle.Result.text);

        // 3. Create a new Entity
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype archetype = entityManager.CreateArchetype(typeof(CharacterStatsComponent));
        Entity characterEntity = entityManager.CreateEntity(archetype);

        // 4. Fill ECS component data
        CharacterStatsComponent statsComponent = new CharacterStatsComponent
        {
            attack = data.stats.attack,
            defense = data.stats.defense,
            health = data.stats.health
        };

        // 5. Add to entity
        entityManager.SetComponentData(characterEntity, statsComponent);

        Debug.Log($"Spawned {data.cardtype} entity for {data.name} with Attack: {statsComponent.attack}, Defense: {statsComponent.defense}, Health: {statsComponent.health}");
    }
}

