using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;// variable para acceder a los comonentes del jugador
    public Vector2 MinPosition; // variable para delimitar la posicion minima
    public Vector2 MaxPosition; // variable para delimitar la posicion maxima
    public float SmoothTime;
    private Vector2 velocity;

    void Start (){}
    void Update(){}
    void FixedUpdate ()
    {

        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, SmoothTime);// suavizamos el movimiento desde la posicion inicial hacia la pocicion donde nos movemos con los pareametros que le indiquemos para el eje X
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, SmoothTime);// suavizamos el movimiento desde la posicion inicial hacia la pocicion donde nos movemos con los pareametros que le indiquemos para el eje Y

        transform.position = new Vector3(Mathf.Clamp(posX, MinPosition.x, MaxPosition.x),Mathf.Clamp(posY, MinPosition.y, MaxPosition.y), transform.position.z);// delimitamos el seguimiento de la camara con los valores maximos y minimos que le asignaremos
	}
}
