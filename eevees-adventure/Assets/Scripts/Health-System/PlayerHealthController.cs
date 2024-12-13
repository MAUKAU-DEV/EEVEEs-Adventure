using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the health for the player character.
/// </summary>
public class PlayerHealthController: HealthSystemBase
{
    [SerializeField] private UnityEvent _deathController;
    [SerializeField] private TMP_Text _healthDisplay;

    private void FixedUpdate()
    {
        UpdateHealthDisplay();
    }

    public override void Die()
    {
        Debug.Log("PLAYER DIES");
        //this._deathController.Invoke();
    }

    /// <summary>
    /// Updates the players health display.
    /// </summary>
    private void UpdateHealthDisplay()
    {
        string displayText = string.Format("{0}", base.currentHealth);
        this._healthDisplay.text = displayText;
    }
}
