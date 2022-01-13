using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float startHealth;

    public float currentHealth { get; private set; }
    public Text HealthCount;

    private void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth); // zabezpieczenie przed ustawieniem wartoœci poni¿ej zera lub powy¿ej pocz¹tkowych ¿yæ

        if (currentHealth > 0)
        {
            HealthCount.text = "Health:" + currentHealth + "/" + startHealth;
        }
        else
        {
            Debug.Log("enemyhealth < 0");
            HealthCount.text = "Health:" + currentHealth + "/" + startHealth;
            Destroy(gameObject);
        }
    }
}
