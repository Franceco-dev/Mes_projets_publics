using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
   [Header("configuration de la vague")] // Seul celui qui a coder 200 ligne de code sur les animation sais ce que celà signifie C'EST UN TABLEAU
   public GameObject enemyPrefabs; // monstre monstre 
   public Transform targetKing; // c'est le roi 
   public int NbreVague = 3;
   public float TempEntreMonstre = 1.50f; // ça on présente lus c'est facile 
   
   [Header("point de Spawn")] // tableau pour les spawns
   public Transform spawnLeft; // on doit mettre dedans enemy
   public Transform spawnRight; // pareille

   private bool isSpawning = false; // on veut éviter avoir 9842930840293404328490 vague en meme temp

    void Update()
    {
        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentEnemies.Length == 0 && !isSpawning)
        {
            StartCoroutine(SpawnNextWave()); // corroutine pour eviter 8034948203909488420843048380940843430 mobs en meme temp
        }
    }

    IEnumerator SpawnNextWave()
    {
        isSpawning = true;

        for (int i = 0; i < NbreVague; i++)
        {
            GameObject enemyR = Instantiate(enemyPrefabs, spawnRight.position, Quaternion.identity);
            Enemy scriptR = enemyR.GetComponent<Enemy>();
            if (scriptR != null) scriptR.target = targetKing;

             GameObject enemyL = Instantiate(enemyPrefabs, spawnLeft.position, Quaternion.identity);
            Enemy scriptL = enemyL.GetComponent<Enemy>();
            if (scriptL != null) scriptL.target = targetKing;

            yield return new WaitForSeconds(TempEntreMonstre);
        }
        isSpawning = false;
    } 
}
