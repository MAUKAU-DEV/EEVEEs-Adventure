using System;
using UnityEngine;

/// <summary>
/// The HealthSystemBase manages the health and damge for the characters.
/// <see href="https://github.com/MAUKAU-DEV/EEVEEs-Adventure/wiki">Documentaion</see>
/// </summary>
public abstract class HealthSystemBase : MonoBehaviour
{
    public int maxHealth = 1;
    public int startHealth = 1;

    public int currentHealth;
    public DamageCategories damageCategory;

    private void Awake()
    {
        this.currentHealth = this.startHealth;
    }

    public virtual void Die()
    {
        Destroy(this);
    }

    /// <summary>
    /// Removes the damage from the characters health.
    /// </summary>
    /// <param name="damage">The amount of damage to be removed.</param>
    /// <returns>True if character is dead.</returns>
    public virtual bool AddDamage(int damage)
    {
        this.currentHealth = this.currentHealth - damage;

        if(this.currentHealth <= 0)
        {
            Die();
            return true;
        } else
        {
            return false;
        }
    }

    /// <summary>
    /// Adds a amount to the current health.
    /// </summary>
    /// <param name="newHealth">The amount to add to the current health.</param>
    /// <returns>The current health.</returns>
    public virtual int AddHealth(int newHealth)
    {
        if (newHealth <= 0)
        {
            Debug.LogError("Cant add negative health.");
            return 0;
        }

        if (this.maxHealth > (this.currentHealth + newHealth))
        {
            Debug.LogWarning("Cant add more health thane MAX_HEALTH.");
            this.currentHealth = this.maxHealth;
            return this.currentHealth;
        }

        this.currentHealth += newHealth;
        return this.currentHealth;
    }
}
