using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform From, To; // declaramos 2 variables para las pociciones inicales y finales

    void OnDrawGizmosSelected()
    {
        if (From != null && To != null) // se comprueva que tenga alguna pocision existente
        {
            Gizmos.color = Color.white;//escojemos el color blanco
            Gizmos.DrawLine(From.position, To.position); //se dibuja una linea desde en inicio hasta el final seleccionado
            Gizmos.DrawSphere(From.position, 0.10f);// se le asigna una esfera para un mejor manejo
            Gizmos.DrawSphere(To.position, 0.10f);// se le asigna una esfera para una mejor visualizacion
        }
    } 
}