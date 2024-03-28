using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliverMovement : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    private void Update()
    {
        // vi vill: få input från spelaren och sen applicera movement till spriten
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // vi måste lagra variablerna horizontal och vertical i en vektor för att man ska kunna gå horizontellt och vertikalt samtidigt

        Vector3 direction = new Vector3(horizontal, vertical);

        // nu har vi en riktning, nu måste vi bara lägga till den till vår nuvarande position, detta gör vi i en fixedupdate eftersom vi först vill att programmet ska leta räkna ut collitions före spelaren rör sig 

    }

    private void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
