using UnityEngine;

public class PetFollow : MonoBehaviour
{
    [SerializeField] public float speed;

    [SerializeField] public float targetPosition;
    [SerializeField] public Transform playerTransform;

    Rigidbody2D myRigidbody2D;
    
    Animator animator;

    Transform target;
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        TargetFollow();
    }

    void TargetFollow()
    {
        if(Vector2.Distance(transform.position, target.position)> targetPosition)
        {
            animator.SetBool("Running", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
