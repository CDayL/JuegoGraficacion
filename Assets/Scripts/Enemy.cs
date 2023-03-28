using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //VARIABLES
    [SerializeField] int health = 1; // Salud actual del enemigo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //METODO PARA REDUCIR VIDA AL ENEMIGO
    public void TakeDamage()
    {
        // Reducir la variable en -1
        health--;
    }
}
