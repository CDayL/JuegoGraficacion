using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //VARIABLES
    [SerializeField] int addedTime = 10; // Tiempo que se añade de mas con la pastilla

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //CUANDO SE ACERCA EL JUGADOR A UNA PASTILLA DE TIEMPO
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aumento tiempo de juego
            GameManager.Instance.time += addedTime;
            // Destruyo la pastilla
            Destroy(gameObject, 0.1f);
        }
    }
}
