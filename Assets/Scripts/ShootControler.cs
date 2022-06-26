using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControler : MonoBehaviour
{
    public GameObject Player;
    public float SpeedShot;
    public GameObject FirePoint;

    void Start ()
    {

    }
	void Update (){}
    void FixedUpdate(){}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}