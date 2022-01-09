using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OficerEnemy : MonoBehaviour
{
    [SerializeField] private float attact;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator animator;
    private Health playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //oficer atakuje kiedy blisko jest Player
        if (PlayerInSight())
        {
            if (cooldownTimer >= attact)
            {
                cooldownTimer = 0;
                animator.SetTrigger("OficerAttact");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null; // true jeœli collider jest ró¿ny od null
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
