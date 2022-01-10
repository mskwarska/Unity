using UnityEngine;

public class PlayerSwordAttact : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    private Animator animator;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)// && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("attact");
        cooldownTimer = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyDog"))
        {
            collision.collider.GetComponent<Health>().TakeDamage(1);
        }
    }
}
