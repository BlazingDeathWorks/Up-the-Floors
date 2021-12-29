using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public static LightSpawner Instance = null;
    [SerializeField] private Light lightPrefab = null;
    private List<Vector2> takenPositions = new List<Vector2>();
    private Queue<GameObject> lightInstances = new Queue<GameObject>();

    private void Awake()
    {
        //Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        //Add Light on TimerEnded
        TimerManager.TimerEnded += InstantiateLight;
    }

    //When Light Gameobject is destroyed...
    public void AddLightToQueue(GameObject lightObject)
    {
        lightInstances.Enqueue(lightObject);
        takenPositions.Remove(lightObject.transform.position);
    }

    private void InstantiateLight()
    {
        Vector2 randomPosition;

        if (takenPositions.Count >= WindowsManager.Windows.Length || lightPrefab == null) return;

        do
        {
            randomPosition = WindowsManager.Windows[Random.Range(0, WindowsManager.Windows.Length)].position;
        } while (takenPositions.Contains(randomPosition));
        takenPositions.Add(randomPosition);

        if (lightInstances.Count == 0) Instantiate(lightPrefab, randomPosition, Quaternion.identity);
        else
        {
            GameObject instance = lightInstances.Dequeue();
            instance.transform.position = randomPosition;
            instance.SetActive(true);
        }
    }
}
