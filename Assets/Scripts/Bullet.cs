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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime; // La bala se mueve a la derecha y normalizarlo
    }
}
