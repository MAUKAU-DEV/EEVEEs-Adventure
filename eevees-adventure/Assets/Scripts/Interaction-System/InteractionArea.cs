using Unity.VisualScripting;
using UnityEngine;

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

    public override void TriggerAction()
    {
        Debug.Log("AREA ACTION");
        base._actionEvent.Invoke();
    }

    #region SETTER/GETTER
    public void SetCanActionPerform(bool changedValue)
    {
        this._actionPerformed = changedValue;
    }

    public bool GetActionPerformed()
    {
        return this._actionPerformed;
    }

    #endregion
}
