using UnityEngine;
using System.Collections;

// Ce script a été réalisé en partie seul et j'ai utilisé des tutos, IA pour finaliser le script final. J'ai bien compris le fonctionnement global.
public class WaveSpawner : MonoBehaviour
{
   [Header("configuration de la vague")] // Un attribut qui permet de controller dans l'interface graphique de Unity les vageus grâce au gameObject Wavespawn.
   public GameObject enemyPrefabs; // Modèle de l'enemy (l'enemie du jeu). 
   public Transform targetKing; // C'est le roi. 
   public int NbreVague = 3; // Trois vagues.
   public float TempEntreMonstre = 1.50f; // Ça on présente lus c'est facile. 
   
   [Header("point de Spawn")] // Tableau pour les spawns. 
   public Transform spawnLeft; // On doit mettre dedans enemy.
   public Transform spawnRight; // Pareille.

   private bool isSpawning = false; // On applique une bollean pour verifié l'etat de réaparition.

    void Update() 
    {
        GameObject[] currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentEnemies.Length == 0 && !isSpawning) // Si il y a pas d'enemys et que l'état est faux on lance la prochaine vague.
        {
            StartCoroutine(SpawnNextWave()); // Corroutine pour eviter 300 enemy en meme temp.
        }
    }

    IEnumerator SpawnNextWave() // Configuration de la coroutine.
    {
        isSpawning = true; // L'état du spawn est vrai.

        for (int i = 0; i < NbreVague; i++) // Repete autant de fois que le nbre de vague c'est à dire 3.
        {
            GameObject enemyR = Instantiate(enemyPrefabs, spawnRight.position, Quaternion.identity); // Apparition de 1 monstre à droite.
            Enemy scriptR = enemyR.GetComponent<Enemy>();
            if (scriptR != null) scriptR.target = targetKing; // Se dirige vers le roi.

            GameObject enemyL = Instantiate(enemyPrefabs, spawnLeft.position, Quaternion.identity); // Apparition de 1 monstre à gauche.
            Enemy scriptL = enemyL.GetComponent<Enemy>(); 
            if (scriptL != null) scriptL.target = targetKing; // Se dirige vers le roi.

            yield return new WaitForSeconds(TempEntreMonstre);
        }
        isSpawning = false; // On remet à faux l'état du spawn.
    } 
}
