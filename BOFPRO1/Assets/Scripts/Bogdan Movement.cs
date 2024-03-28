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
        // vi vill: f� input fr�n spelaren och sen applicera movement till spriten
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;

        // vi m�ste lagra variablerna horizontal och vertical i en vektor f�r att man ska kunna g� horizontellt och vertikalt samtidigt

        rb.velocity = new Vector2 (speedX, speedY);

        // nu har vi en riktning, nu m�ste vi bara l�gga till den till v�r nuvarande position, detta g�r vi i en fixedupdate eftersom vi f�rst vill att programmet ska leta r�kna ut collitions f�re spelaren r�r sig 

    }


}
