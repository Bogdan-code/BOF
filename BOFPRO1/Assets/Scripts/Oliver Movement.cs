using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliverMovement : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    private void Update()
    {
        // vi vill: f� input fr�n spelaren och sen applicera movement till spriten
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // vi m�ste lagra variablerna horizontal och vertical i en vektor f�r att man ska kunna g� horizontellt och vertikalt samtidigt

        Vector3 direction = new Vector3(horizontal, vertical);

        // nu har vi en riktning, nu m�ste vi bara l�gga till den till v�r nuvarande position, detta g�r vi i en fixedupdate eftersom vi f�rst vill att programmet ska leta r�kna ut collitions f�re spelaren r�r sig 

    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
