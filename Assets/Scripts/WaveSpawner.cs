using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;
    public GameObject fightingArea; 

    private BoxCollider areaCollider;

    // Start is called before the first frame update
    void Start()
    {
        if (fightingArea != null)
        {
            areaCollider = fightingArea.GetComponent<BoxCollider>();
            if (areaCollider == null)
            {
                Debug.LogError("The fighting area needs a BoxCollider to define the spawn area.");
                return;
            }
        }
        else
        {
            Debug.LogError("Fighting area is not assigned!");
            return;
        }
        WavesManager.instance.waves.Add(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    // Spawns a prefab at a random position within the fighting area
    void Spawn()
    {
        if (areaCollider == null) return;

        Vector3 randomPosition = GetRandomPositionInArea();
        Instantiate(prefab, randomPosition, Quaternion.identity);
    }

    void EndSpawner()
    {
        WavesManager.instance.waves.Remove(this);
        CancelInvoke();
    }
    // Get a random position within the fighting area (using the bounds of the BoxCollider)
    Vector3 GetRandomPositionInArea()
    {
        Bounds bounds = areaCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = bounds.max.y;
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}