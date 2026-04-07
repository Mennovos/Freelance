using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private string islandcode;
    [SerializeField] private int Niveau;
    [SerializeField] private GameObject barrier;

    [Header("All of the spawnpoints needed")]
    [SerializeField] private List<Transform> SpawnpointsEnemies;
    [SerializeField] private List<Transform> SpawnpointsPickups;

    [Header("In game Enemies and pickups")]
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private List<GameObject> Pickups;

    [Header("Spawnable Enemies and Pickups")]
    [SerializeField] public List<GameObject> spawnEnemies;
    [SerializeField] public List<GameObject> spawnPickups;


    private void Start()
    {
        barrier.SetActive(true);
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        float distanceToPlayer = (playerController.transform.position - transform.position).magnitude;
        if (distanceToPlayer < 50f)
        {
            for (int i = 0; i < SpawnpointsEnemies.Count; i++)
            {
                if (spawnEnemies.Count < Niveau)
                {
                    GameObject Enemy = Instantiate(Enemies[Random.Range(0, Enemies.Count)], SpawnpointsEnemies[i].position, Quaternion.identity);
                    spawnEnemies.Add(Enemy);
                    Enemy.GetComponent<Enemy>().SetIslandParent(this);
                }
            }
            if (spawnEnemies.Count == 0)
            {
                Debug.Log("All enemies on the island are dead.");
                barrier.SetActive(false);
                if (spawnPickups.Count < SpawnpointsPickups.Count)
                {
                    GameObject Pickup = Instantiate(Pickups[Random.Range(0, Pickups.Count)], SpawnpointsPickups[spawnPickups.Count].position, Quaternion.identity);
                    spawnPickups.Add(Pickup);
                }
            }
        }
    }

}
