using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckG : MonoBehaviour
{
    private PlayerControler Player; // variable para acceder a las vdemas variables dentro del jugador
    private Rigidbody2D rb2d;
    public bool WaterG;

    void Start ()
    {
        Player = GetComponentInParent<PlayerControler>(); // recogemos el componenteS
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    void Update(){}
    public void OnCollisionStay2D(Collision2D collision) // compueva el inicio de una colision
    {
        if (collision.gameObject.tag == "Ground") // si se coliciona con un objeto que tenga un tag "ground" entonces.....
        {
            Player.Grounded = true; // el valor es verdadero
        }

        if (collision.gameObject.tag == "Platform")
        {
            Player.Grounded = true;
            Player.Speed = 100;
            rb2d.velocity = new Vector3(0f, 0f, 0f);//al colicionar por primera ves con una plataforma no se movera                 P E N D I E N T E
            Player.transform.parent = collision.transform;  // hace hijo al objeto con el que coliciona
        }
    }
    public void OnCollisionExit2D(Collision2D collision) // compueva el final de una colision
    {
        if (collision.gameObject.tag == "Ground")// si se deja de colicionar con un objeto que tenga un tag "ground" entonces....
        {
            Player.Grounded = false;// el valor es falso 
        }
        if (collision.gameObject.tag == "Platform")
        {
            Player.Speed = 10;
            Player.transform.parent = null;
            Player.Grounded = false;
        }
    }
}