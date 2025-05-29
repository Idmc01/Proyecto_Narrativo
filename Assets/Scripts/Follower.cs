using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;  // Referencia al jugador (player)
    public float speed = 3f;  // Velocidad del seguidor
    public float followDistance = 1.5f;  // Distancia mínima para seguir

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if (distance > followDistance)
        {
            moveDirection = direction.normalized;
            Vector2 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            // Actualizar animaciones
            animator.SetFloat("InputX", moveDirection.x);
            animator.SetFloat("InputY", moveDirection.y);
        }
        else
        {
            // Cuando está cerca, deja de moverse y animaciones a 0
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", 0);
        }
    }
}

