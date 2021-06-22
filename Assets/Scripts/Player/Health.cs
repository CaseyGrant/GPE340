using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public Slider health;

    public UnityEvent OnHeal;

    public void Start()
    {
        UpdateSlider();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(float amountToHeal)
    {
        currentHealth += amountToHeal;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        OnHeal.Invoke();
    }

    public void UpdateSlider()
    {
        health.value = currentHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        UpdateSlider();
    }

    public void Death()
    {
        currentHealth = maxHealth;
        GameManager.Instance.GetComponent<DeathController>().Death();
        gameObject.SetActive(false);
    }
}
