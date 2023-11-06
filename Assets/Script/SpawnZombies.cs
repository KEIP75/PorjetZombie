using UnityEngine;
using System.Collections;

public class SpawnZombies : MonoBehaviour
{
    public GameObject zombiePrefab; 
    public Transform[] spawnPoints; 
    public int nombreZombiesParRound = 10; 

    public float delaiEntreSpawns = 3f; 

    void Start()
    {
        StartCoroutine(SpawnZombiesUnParUn());
    }

    IEnumerator SpawnZombiesUnParUn()
    {
        int zombiesSpawnes = 0;

        while (zombiesSpawnes < nombreZombiesParRound)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Fais apparaître un zombie au point de spawn choisi
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

            // Assigne le zombie au tag qui comporte le tag Player
            zombie.GetComponent<ZombieScript>().Cible = GameObject.FindWithTag("Player").transform;

            zombiesSpawnes++;

            yield return new WaitForSeconds(delaiEntreSpawns);
        }
    }
}
