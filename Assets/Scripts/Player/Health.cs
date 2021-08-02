using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Vector3 pos; // holds the position

    [SerializeField] private float maxHealth; // the max health
    [SerializeField] private float currentHealth; // the current health
    public float lives = 1;

    public Slider health; // the slider linked to the health
    public Image livesUI;

    public UnityEvent OnHeal; // what happens when healed

    public void Start()
    {
        UpdateSlider(); // updates the health sliders
    }

    public void Update()
    {
        if (currentHealth <= 0) // if dead
        {
            pos = gameObject.transform.position; // updates the position
            Death(); // kill
            if (gameObject.CompareTag("Enemy"))
            {
                Instantiate(GameManager.Instance.GetComponent<DropManager>().DropItem(), pos, Quaternion.identity); // spawns an item drop
            }
            
        }
        if (gameObject.CompareTag("Player"))
        {
            livesUI.fillAmount = lives / 3; // updates the lives UI
        }
        

        if (lives <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject); // destroys the enemy
            }
            if (gameObject.CompareTag("Player"))
            {
                GameManager.Instance.EndGame(); // sends the player to the main menu
            }
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
