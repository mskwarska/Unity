using UnityEngine;

public class EnemyPikes : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
