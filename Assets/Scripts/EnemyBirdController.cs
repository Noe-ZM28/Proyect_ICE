using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdController : MonoBehaviour {

    public PlayerControler Player; // variable para acceder a las vdemas variables dentro del jugador
    public int Damage;

    void Start ()
    {
        Player = GetComponent<PlayerControler>(); // recogemos el componenteS
    }
    void Update (){}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Health = Player.Health - Damage;
        }
    }
}