using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VARIABLES
    Transform player; // Referencia al transform del jugador
    [SerializeField] int health = 1; // Salud actual del enemigo
    [SerializeField] float speed = 1; // Controlar velocidad del enemigo

    // Start is called before the first frame update
    void Start()
    {
        // Referencia de player
        player = FindObjectOfType<Player>().transform;

        // Referencia de los SpawnPoints
        GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        // Enemigo escoja aleatoriamente un spawnpoint desde cero hasta la cantidad de spawnpoints que aiga
        int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
        transform.position = spawnPoint[randomSpawnPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener direccion hacia el enemigo
        Vector2 direction = player.position - transform.position; // Restamos la posicion del jugador y el enemigo
        //Afectar la posicion actual del enemigo
        transform.position += (Vector3)direction.normalized * Time.deltaTime;
    }

    //METODO PARA REDUCIR VIDA AL ENEMIGO
    public void TakeDamage()
    {
        // Reducir la variable en -1
        health--;
        // Cuando la vida del enemigo llegue a 0
        if (health <= 0)
        {
            // Destruir el enemigo
            Destroy(gameObject);
        }
    }

    //CUANDO SE ACERCA EL ENEMIGO AL JUGADOR
    private void OnTriggerEnter2D(Collider2D collision) //collision guarda el objeto con el que choca el enemigo
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage();
        }
    }
}
