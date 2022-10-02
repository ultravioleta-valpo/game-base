using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2DJugador : MonoBehaviour
{
    //inicializa la velocidad, el rigidbody y un vector2D

    
    public Rigidbody2D playerRB; // definimos variable tipo Rigidbody2D pero sin inicializarla
    // usaremos el objeto camara para pasar de Pos. Pantalla --> Unidades Mundo Interno
    public Camera camara;


    public float velocidad = 5f; //asi se define una variable inicializada

    // si no se especifica public o private queda como default que?
    Vector2 deltaMovimiento;
    Vector2 posicionMouse;
    Vector2 rayoMira; // posicionMouse - posicionJugador

    // Update is called once per frame
    void Update() //ocurre cada frame, se usa para leer
    {
        //leer la input para el movimiento
        deltaMovimiento.x = Input.GetAxisRaw("Horizontal");
        deltaMovimiento.y = Input.GetAxisRaw("Vertical");

        // leer la input del Mouse y usamos camara para pantalla -> mundo
        posicionMouse = camara.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() //ocurre menos veces que update, se usa para la fisica
    {
        // ---- movimiento 2D --------
        deltaMovimiento.Normalize();
        deltaMovimiento = Time.deltaTime * velocidad * deltaMovimiento;
        // sumar el vector de movimiento
        playerRB.MovePosition(playerRB.position + deltaMovimiento );

        // ---- angulo 2D --------
        rayoMira = posicionMouse - playerRB.position;
        // ahora necesito el angulo para la rotacion
        playerRB.rotation = (Mathf.Atan2(rayoMira.y, rayoMira.x) * Mathf.Rad2Deg ) - 90f;
    }
}
