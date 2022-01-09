using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
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
            //game over
            HealthCount.text = "Health:" + currentHealth + "/" + startHealth;
            GetComponent<Movement>().enabled = false;
            isDead = true;
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Spikes"))
    //    {
    //        TakeDamage(1);
    //    }
    //}
}
