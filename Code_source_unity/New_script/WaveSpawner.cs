using UnityEngine;
using System.Collections;
//ce script a été réalisé en parti seul et j'ai utilisé des tutos, IA pour finaliser le script final j'ai bien compris le fonctionnement global
public class WaveSpawner : MonoBehaviour
{
   [Header("configuration de la vague")] // un attribut qui permet de controller dans l'interface graphique de unity les vageus grâce au gameObject Wavespawn
   public GameObject enemyPrefabs; // modèle de l'enemy (l'enemie du jeu) 
   public Transform targetKing; // c'est le roi 
   public int NbreVague = 3; // trois vagues
   public float TempEntreMonstre = 1.50f; // ça on présente lus c'est facile 
   
   [Header("point de Spawn")] // tableau pour les spawns 
   public Transform spawnLeft; // on doit mettre dedans enemy
   public Transform spawnRight; // pareille

   private bool isSpawning = false; //on applique une bollean pour verifié l'etat de réaparition

    void Update() 
    {
        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentEnemies.Length == 0 && !isSpawning) //si il y a pas d'enemy et que l'état est faux on lance la prochaine vague
        {
            StartCoroutine(SpawnNextWave()); // corroutine pour eviter 300 enemy en meme temp
        }
    }

    IEnumerator SpawnNextWave() //configuration de la coroutine
    {
        isSpawning = true; //l'état du spawn est vrai

        for (int i = 0; i < NbreVague; i++) // repete autant de fois que le nbre de vague c'est à dire 3
        {
            GameObject enemyR = Instantiate(enemyPrefabs, spawnRight.position, Quaternion.identity); // apparition de 1 monstre à droite
            Enemy scriptR = enemyR.GetComponent<Enemy>();
            if (scriptR != null) scriptR.target = targetKing; // se dirige vers le roi

             GameObject enemyL = Instantiate(enemyPrefabs, spawnLeft.position, Quaternion.identity); // apparition de 1 monstre à gauche
            Enemy scriptL = enemyL.GetComponent<Enemy>(); 
            if (scriptL != null) scriptL.target = targetKing; // se dirige vers le roi

            yield return new WaitForSeconds(TempEntreMonstre);
        }
        isSpawning = false; //on remet à faux l'état du spawn
    } 
}
