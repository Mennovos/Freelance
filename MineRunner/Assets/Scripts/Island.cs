using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private string islandcode;
    [SerializeField] private int Niveau;
    [SerializeField] private GameObject barrier;

    [SerializeField] private List<Transform> Spawnpoints;
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private List<GameObject> Pickups;

    [Header("Spawnable Enemies and Pickups")]
    [SerializeField] public List<GameObject> spawnEnemies;
     private List<GameObject> spawnPickups;


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
            for (int i = 0; i < Spawnpoints.Count; i++)
            {
                if (spawnEnemies.Count < Niveau)
                {
                    GameObject Enemy = Instantiate(Enemies[Random.Range(0, Enemies.Count)], Spawnpoints[i].position, Quaternion.identity);
                    spawnEnemies.Add(Enemy);
                    Enemy.GetComponent<Enemy>().SetIslandParent(this);
                }
                //if (spawnPickups.Count < Niveau)
                //{
                  //  GameObject Pickup = Instantiate(Pickups[Random.Range(0, Pickups.Count)], Spawnpoints[i].position, Quaternion.identity);
                 //   spawnPickups.Add(Pickup);
                //}
            }
            if (spawnEnemies.Count == 0)
            {
                Debug.Log("All enemies on the island are dead.");
                barrier.SetActive(false);
            }
        }
    }

}
