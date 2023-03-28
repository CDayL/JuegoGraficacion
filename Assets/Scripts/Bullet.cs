using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //VARIABLES
    [SerializeField] float speed = 5; // Velocidad de la bala

    // Start is called before the first frame update
    void Start()
    {
        // Tiempo que duran las balas visibles
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // La bala se mueve a la derecha y normalizarlo
        transform.position += transform.right * Time.deltaTime;
    }

    //CUANDO COLISIONAN LA BALA Y EL ENEMIGO
    private void OnTriggerEnter2D(Collider2D collision) //collision guarda el objeto con el que coliciona la bala
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage();
            // Si la bala toca al enemigo se destruye
            Destroy(gameObject);
        }
    }
}
