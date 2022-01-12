using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float startHealth;
    private bool isDead;

    public float currentHealth { get; private set; }
    public Text HealthCount;

    private void Awake()
    {
        currentHealth = startHealth;
        isDead = false;
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
            //game over
            HealthCount.text = "Health:" + currentHealth + "/" + startHealth;
            Destroy(gameObject);

            //GetComponent<OficerEnemy>().enabled = false;
            isDead = true;
        }
    }
}
