using UnityEngine;

/// <summary>
/// The interaction if the player walks through a area.
/// </summary>
public class InteractionArea : InteractionObject
{
    private bool _actionPerformed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(base._tagCheck)) return;

        if(_actionPerformed) return;

        this._actionPerformed = true;
        TriggerAction();
    }

    /// <summary>
    /// The method that calls the action event.
    /// </summary>
    public override void TriggerAction()
    {
        Debug.Log("AREA ACTION");
        base._actionEvent.Invoke();
    }

    #region SETTER/GETTER

    /// <summary>
    /// Can change if the area is still active.
    /// </summary>
    /// <param name="changedValue">The new value for <code>_actionPerformed</code>.</param>
    public void SetCanActionPerform(bool changedValue)
    {
        this._actionPerformed = changedValue;
    }


    /// <summary>
    /// Returns the value of <code>_actionPerformed</code> of this area.
    /// </summary>
    /// <returns>The <code>_actionPerformed</code> value.</returns>
    public bool GetActionPerformed()
    {
        return this._actionPerformed;
    }

    #endregion
}
