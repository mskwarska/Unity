using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth);

        if (currentHealth > 0)
        {
            HealthCount.text = "Health:" + currentHealth + "/" + startHealth;
        }
        else
        {
            //game over
            HealthCount.text = "Health:" + currentHealth + "/" + startHealth;
            SceneManager.LoadScene(2);
            isDead = true;
        }
    }
}
