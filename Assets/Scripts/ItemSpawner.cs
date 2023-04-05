using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //VARIABLES
    [SerializeField] GameObject checkpointPrefab; // Referencia al checkpoint
    [SerializeField] int checkpointSpawnDelay = 10; // Cada 10 seg aparece una nueva pastilla de tiempo
    [SerializeField] float spawnRadius = 10; // Radio presiso

    // Start is called before the first frame update
    void Start()
    {
        // Llamado de la cortina
        StartCoroutine(SpawnCheckpointRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // CREAR PASTILLAS DE TIEMPO
    IEnumerator SpawnCheckpointRoutine()
    {
        while (true)
        {
            // Aparece una nueva pastilla de tiempo
            yield return new WaitForSeconds(checkpointSpawnDelay);
            // Crear posicion aleatoria
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            // Crear una pastilla, pasar la posicion
            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
    }
}
