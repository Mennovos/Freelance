using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private int Niveau;
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private List<GameObject> Pickups;
    [SerializeField] private List<Transform> Spawnpoints;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        float distanceToPlayer = (playerController.transform.position - transform.position).magnitude;
        if (distanceToPlayer < 50f)
        {
            for (int i = 0; i < Spawnpoints.Count; i++)
            {
                if (Enemies.Count < Niveau)
                {
                    GameObject Enemy = Instantiate(Enemies[Random.Range(0, Enemies.Count)], Spawnpoints[i].position, Quaternion.identity);
                    Enemies.Add(Enemy);
                }
                if (Pickups.Count < Niveau)
                {
                    GameObject Pickup = Instantiate(Pickups[Random.Range(0, Pickups.Count)], Spawnpoints[i].position, Quaternion.identity);
                    Pickups.Add(Pickup);
                }
            }
        }
    }
}
