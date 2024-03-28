using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // vi vill: f� input fr�n spelaren och sen applicera movement till spriten
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;

        // vi m�ste lagra variablerna horizontal och vertical i en vektor f�r att man ska kunna g� horizontellt och vertikalt samtidigt

        rb.velocity = new Vector2 (speedX, speedY);

    }


}
