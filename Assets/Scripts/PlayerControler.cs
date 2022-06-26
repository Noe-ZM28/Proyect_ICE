using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [Header("Movimiento")]
    public float Speed = 3.5f; // variable para la velocidad
    public float MaxSpeed = 7; // variable para regular la velocidad del Player
    public float NomberCorrection = 0.65f;
    public bool DownMove = false;
    public bool Move = true; 
    [Header("Salto")]
    public float JumpPower= 5; // variable de fuerza para saltar
    public bool Jump; // variable para con provar  salto
    public bool DoubleJump; // Variable para hacer el soble salto/ salto de emergencia
    [Header("Vida")]
    public int Health = 100; // variable para gestionar la salud
    [Header("Elementos")]
    public bool Grounded; // variable para comprovar si se toca el suelo o no
    public bool OnWater;
    public Vector3 CheckRespawn;
    [Header("Componentes del jugador")]
    public Rigidbody2D rb2d;//variable para acceder a los componentes del Rigidbody2D del personaje
    public SpriteRenderer sr;
    
    void Start () //se ejecuta en cuanto inicia el juego
    {
        rb2d = GetComponent<Rigidbody2D>(); // regresamos el valor del Rigidbody2D
        sr = GetComponent<SpriteRenderer>();
        //Respawn();
    }
    private void Update(){}
    void FixedUpdate() // variables para usar las fisicas del juego
    {
        if ((Input.GetKeyDown(KeyCode.RightArrow)) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move = true;
        }
        else
        {
            Move = false;
        }
        Vector3 fixedVelocity = rb2d.velocity; // se crea un vector con los parametros de la velocidad
        fixedVelocity.x *= NomberCorrection; // se multiplica la velocidad por ese numero para disminuirla
        if (Grounded)// comprueba si se toca el suelo
        {
            rb2d.velocity = fixedVelocity;// las variables valen lo mismo
        }
        float M = Input.GetAxis("Horizontal"); // detecta que precionaremos teclas hacia la derecha como la izquierda
        rb2d.AddForce(Vector2.right * Speed * M); // añade una fuerza a la velocidad del Rb del player y la multiplica por la velovidad y por la direccion del vector asignada
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -MaxSpeed, MaxSpeed); // delimirta la velociDAD DEL JUGADOR ENTRE 2 VALOES
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y); // REASIGNA LA VELOCIDAD CON LOS VALORES CORREGIDOS
        if (M > 0)
        {
            transform.localScale = new Vector3(1, 1f, 1f); // si la velocidad es menor, entonces se mira a la derecha
        }
        if (M < 0)
        {
        transform.localScale = new Vector3(-1, 1f, 1f);// si es mayor entonces se mira a la izquierda
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownMove = true;
            Speed = 20;
            MaxSpeed = 15;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            DownMove = false;
            MaxSpeed = 10;
            Speed = 10;
        }
        if (Input.GetKeyDown(KeyCode.Space)) // detecta que se preciona una tecla
        {
            if (Grounded) //si estas en el suelo
            {
               Jump = true;//puedes saltar
               DoubleJump = true; //puedes volver a saltar
            }
            else if (DoubleJump)//si el soble salto es verdadero
            {
               Jump = true;// puedes saltar de nuevo
               DoubleJump = false;// ya no puedes saltar
            }
        }       
        if (Jump)
        {
            Jumper();
        }
        //Debug.Log(rb2d.velocity.x);// IMPRIME EN TODO MOMENTO LA VELOCIDAD ACTUAL
        Mathf.Clamp(Health, 0, 100);
    }
    private void OnBecameInvisible() // se ejecuta encuanto un elemento sale del area asignada (campo de vision)
    {
        Dead();// llama al proceso de morir para que se ejecute
    }
    public void Jumper()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0); //da el valor de 0 al inicio 
        rb2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);// agrega el impulso pasa saltar
        Jump = false;// desactiva el salto
    }
    public void Dead() // es un proceso que se ejecuta cuando se le llama y permite morir al jugador
    {
        transform.position = new Vector3(0, 2, 0); //cambia la pocicion del objeto a la nueva asignada
        Debug.Log("YOU DEAD"); // imprime un mensaje en la consola
        rb2d.velocity = new Vector3(0f, 0f, 0f);// quitar la velocidad al reaparecer
    }
    public void Respawn()
    {
        transform.position = CheckRespawn;
    }
}