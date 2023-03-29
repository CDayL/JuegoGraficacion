using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //VARIABLES
    float h; //Contiene informacion del eje horizontal del jugador
    float v; //Contiene informacion del eje vertical del jugador
    Vector3 moveDirection; //Vector de movimiento
    [SerializeField]float speed = 3; //Velocidad del jugador
    [SerializeField] Transform aim; // Referencia a mira
    [SerializeField] Camera camera; // Referencia a la camera
    Vector2 facingDirection; // Direccion a la que voltea la mira o jugador
    [SerializeField] Transform bulletPrefab;// Referencia a la bala o prefab
    bool gunLoaded = true; //Saber si esta cargada con una bala
    [SerializeField] float fireRate = 1; // Variable para controlar numero de balas
    [SerializeField] int health = 10; // Afectar la salud del jugador

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO DEL JUGADOR

        h = Input.GetAxis("Horizontal"); // Extraer informacion del imput horizontal del teclado (Letras A y D o flechas izquierda y derecha)
        v = Input.GetAxis("Vertical"); // Extraer informacion del imput vertical del teclado (Letras W y S o flechas arriba y abajo)

        //Acceder al componente transform
        moveDirection.x = h;
        moveDirection.y = v;

        transform.position += moveDirection * Time.deltaTime * speed; //Sumar moveDirection a la posicion del jugador, normalizar el vector con respecto al movimiento con Time.deltaTime y multiplicar por la velocidad deceada osea speed

        // MOVIMIENTO DE LA MIRA

        facingDirection = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position; // Asignar posicion con respecto a la camara, traducir la posicion del puntero al espacio del mundo; resta la posicion del jugador. Obtenemos una direccion que guarda facingDirection

        aim.position = transform.position + (Vector3)facingDirection.normalized; //Asignar direccion obtenida a aim.position; debes sumar la posicion del jugador, agragar un espacio fijo alrededor del jugador

        //CREACION DE BALA

        if (Input.GetMouseButton(0) && gunLoaded)
        {
            // No podre disparar ya que no esta cargada el arma
            gunLoaded = false;
            // Obtener angulo entre jugador y mira para darlo en radianes
            float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
            // Crear un Quaternion para sacar la rotacion que queremos
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Crear bala en la posicion del jugador con su rotacion
            Instantiate(bulletPrefab, transform.position, targetRotation);
            // Espera un segundo y recarga la bala permitiendote disparar
            StartCoroutine(ReloadGun());
        }
    }

    // CORRUTINA (Creamos tiempo para recargar la bala)

    IEnumerator ReloadGun ()
    {
        // Crear tiempo de retraso
        yield return new WaitForSeconds(1/fireRate);
        // Recargar el arma con una bala
        gunLoaded = true;
    }

    // METODO PARA REDUCIR VIDA AL JUGADOR
    public void TakeDamage()
    {
        // Reducir la vida del jugador
        health--;
    }
}
