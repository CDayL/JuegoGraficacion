using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // VARIABLES
    public static GameManager Instance; //Tener acceso desde otros scrips, no es recomedable crear variables staticas todo el tiempo; arranca cuando inicia el juego y se detiene hasta que termina
    public int time = 30; // Contador de tiempo del juego, quitamos el serializado y la dejamos publica
    public int difficulty = 1; // Controlar dificultad del juego

    /// // Start is called before the first frame update
    void Start()
    {
        // Hace el llamado al tiempo del juego
        StartCoroutine(CountdownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            // this contiene toda la informacion que tiene GameManager
            Instance = this;
        }
    }

    //TIEMPO DEL JUEGO
    IEnumerator CountdownRoutine()
    {
        while (time > 0)
        {
            // Esperar un segundo para disminuir el tiempo
            yield return new WaitForSeconds(1);
            // Disminuir en 1
            time--;
        }

        //Game Over
    }
}
