using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;
    private Vector3 direction;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // vi vill: få input från spelaren och sen applicera movement till spriten
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;

        // vi måste lagra variablerna horizontal och vertical i en vektor för att man ska kunna gå horizontellt och vertikalt samtidigt

        rb.velocity = new Vector2 (speedX, speedY);

        // nu har vi en riktning, nu måste vi bara lägga till den till vår nuvarande position, detta gör vi i en fixedupdate eftersom vi först vill att programmet ska leta räkna ut collitions före spelaren rör sig 

    }


}
