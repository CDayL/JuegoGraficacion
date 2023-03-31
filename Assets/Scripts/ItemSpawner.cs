using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //VARIABLES
    [SerializeField] GameObject checkpointPrefab; // Referencia al checkpoint

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Llamado de la cortina
        StartCoroutine(SpawnCheckpointRoutine());
    }
    
    // CREAR PASTILLAS DE TIEMPO
    IEnumerator SpawnCheckpointRoutine()
    {
        while (true)
        {
            // Cada tres segundo aparece una nueva pastilla de tiempo
            yield return new WaitForSeconds(3);
            // Crear posicion aleatoria
            Vector2 randomPosition = Random.insideUnitCircle * 5;
            // Crear una pastilla, pasar la posicion
            Instantiate(checkpointPrefab, randomPosition, Quaternion.identity);
        }
    }
}
