using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Transform Target;// declaramos una variable para la posicion
    public float SpeedMove; // y otra para la velocidad
    private Vector3 start, end;

    void Start ()
    {
        if (Target != null)// se comprueba que exista la posicion
        {
            Target.parent = null;// hacemos que deje de ser un objeto hijo del otro
            start = transform.position; // asignamos la pocicion inicial a la variable
            end = Target.position; // asignamos la pocicion del END a la variable
        }
	}
	void FixedUpdate () {
        if (Target != null)// se comprueba que exista la posicion
        {
            float EndFix = SpeedMove * Time.deltaTime; // asiganamosnuna nueva variable para multiplicarla velocidad por el time delta time para la correcion
            transform.position = Vector3.MoveTowards(transform.position, Target.position, EndFix);// cambialos la pocicion hacia las asignadas y le pasaos la velocidad corregida
        }
        if (transform.position == Target.position) // si las pociciones son las mismas
        {
            if (Target.position == start) // si la pocicion inicial es igual a la de la inicial
            {
                Target.position = end; // la pocision es la misma
            }
            else
            {
                Target.position = start; // sino la pocicion sera la inicial
            }
        }
	}
}