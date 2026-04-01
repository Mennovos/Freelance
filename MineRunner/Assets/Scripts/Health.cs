using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthBar;

    void Update()
    {
       healthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public float gethealth()
    {
        return (float)currentHealth;
    }
    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Entity has died.");
    }
}
