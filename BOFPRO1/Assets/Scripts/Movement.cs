using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        // vi vill: få input från spelaren och sen applicera movement till spriten
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // vi måste lagra variablerna horizontal och vertical i en vektor för att man ska kunna gå horizontellt och vertikalt samtidigt

        Vector3 direction = new Vector3(horizontal, vertical);

        // nu har vi en riktning, nu måste vi bara lägga till den till vår nuvarande position

        transform.position += direction * speed * Time.deltaTime;

    }
}
