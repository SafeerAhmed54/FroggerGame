using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> lane1; // Assign these lists in the Inspector
    [SerializeField] private List<GameObject> lane2;
    [SerializeField] private List<GameObject> lane3;
    [SerializeField] private List<GameObject> lane4;
    [SerializeField] private List<GameObject> lane5;
    [SerializeField] private List<GameObject> lane6; // Assign these lists in the Inspector
    [SerializeField] private List<GameObject> lane7;
    [SerializeField] private List<GameObject> lane8;
    [SerializeField] private List<GameObject> lane9;
    [SerializeField] private List<GameObject> lane10;
    [SerializeField] private float spawnInterval = 2.5f; // Default interval for spawning cars

    private List<List<GameObject>> lanes; // Combined list for all lanes

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the combined lanes list with all individual lanes
        lanes = new List<List<GameObject>> { lane1, lane2, lane3, lane4, lane5 };

        // Start coroutines for each lane to spawn cars gradually
        foreach (var lane in lanes)
        {
            StartCoroutine(CarsSpawn(lane));
        }

        // Initialize the combined lanes list with all individual lanes
        lanes = new List<List<GameObject>> { lane6, lane7, lane8, lane9, lane10 };

        // Start coroutines for each lane to spawn cars gradually
        foreach (var lane in lanes)
        {
            StartCoroutine(LogSpawn(lane));
        }
    }

    // Coroutine to enable cars one by one with a delay for each lane
    IEnumerator CarsSpawn(List<GameObject> lane)
    {
        foreach (GameObject car in lane)
        {
            car.SetActive(true); // Enable the car
            yield return new WaitForSeconds(spawnInterval); // Wait before enabling the next car
        }
    }

    IEnumerator LogSpawn(List<GameObject> lane)
    {
        foreach (GameObject car in lane)
        {
            float spawnInterval2 = 3f;
            car.SetActive(true); // Enable the car
            yield return new WaitForSeconds(spawnInterval2); // Wait before enabling the next car
        }
    }
}
