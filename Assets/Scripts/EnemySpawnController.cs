using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    //VARIABLES
    [SerializeField] GameObject[] enemyPrefab; //Arreglo de controlador de enemigos
    [Range(1, 10)][SerializeField] float spawnRate = 1; // Tiempo en el que se crea un nuevo enemigo

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnNewEnemy ()
    {
        while (true)
        {
            // Cada 3 seg se crea un nuevo enemigo
            yield return new WaitForSeconds(1/spawnRate);
            // Aleatorio para crear a los enemigos
            float random = Random.Range(0.0f, 1.0f);

            if (random < GameManager.Instance.difficulty * 0.1f)
            {
                // Crea el enemigo mas fuerte
                Instantiate(enemyPrefab[0]);
            }
            else
            {
                // Crea el enemigo mas debil
                Instantiate(enemyPrefab[1]);
            }
        }
    }
}
