using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Unit_Health : MonoBehaviour
{
    private Action onDestroy;
    public int currentHealth;


    public void Init(int totalHealth, Action onDestroy)
    {
        currentHealth = totalHealth;
        this.onDestroy = onDestroy;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            onDestroy.Invoke();
        }
    }
    
}
