using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth; // the max health
    [SerializeField] private float currentHealth; // the current health

    public Slider health; // the slider linked to the health

    public UnityEvent OnHeal; // what happens when healed

    public void Start()
    {
            UpdateSlider(); // updates the health sliders
    }

    public void Update()
    {
        if (currentHealth <= 0) // if dead
        {
            Death(); // kill
        }
    }

    public void Heal(float amountToHeal)
    {
        currentHealth += amountToHeal; // heals
        currentHealth = Mathf.Min(currentHealth, maxHealth); // makes sure number is within bounds

        OnHeal.Invoke(); // allows the designers to make heal do more
    }

    public void UpdateSlider()
    {
        health.value = currentHealth; // sets the slider to current health
    }

    public void Damage(int damage)
    {
        currentHealth -= damage; // deals the passed in damage
        UpdateSlider(); // updates the health slider
    }

    public void Death()
    {
        currentHealth = maxHealth; // resets health
        GameManager.Instance.GetComponent<DeathController>().Death(); // kills
    }
}
