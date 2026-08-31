using UnityEngine;
using UnityEngine.UI;

public class Unit_HealthBar : MonoBehaviour
{
    public Slider healthBarSlider;

    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

}
