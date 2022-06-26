using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public PlayerControler Player;
    public Image Image;
    public Sprite Heart_0;
    public Sprite Heart_1;
    public Sprite Heart_2;
    public Sprite Heart_3;
    public Sprite Heart_4;
    public Sprite Heart_5;
    public Sprite Heart_6;

    void Start ()
    {
        Image = GetComponent<Image>();
    }
    private void Update(){}
    void FixedUpdate ()
    {
        if (Player.Health == 100)
        {
            Image.sprite = Heart_0;
        }
        if ((Player.Health < 100) && (Player.Health >= 80))
        {
            Image.sprite = Heart_1;
        }
        if ((Player.Health < 80) && (Player.Health >= 60))
        {
            Image.sprite = Heart_2;
        }
        if((Player.Health < 60) && (Player.Health >= 40))
        {
            Image.sprite = Heart_3;
        }
        if ((Player.Health < 40) && (Player.Health >= 20))
        {
            Image.sprite = Heart_4;
        }
        if ((Player.Health < 20) && (Player.Health >= 1))
        {
            Image.sprite = Heart_5;
        }
        if (Player.Health == 0)
        {
            Image.sprite = Heart_6;
            Player.Dead();
        }

    }

}