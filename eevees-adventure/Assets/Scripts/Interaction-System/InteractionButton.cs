using UnityEngine;

/// <summary>
/// Manages the interactions of the player based on key input.
/// </summary>
public class InteractionButton: InteractionObject
{
    public bool _buttonToggle = true;
    public bool _buttonStartState = false;
    public InteractionPrompt _interactPrompt;

    // Internal
    private InputController _inputController;
    private bool _isPlayerInside = false;
    private bool _wasUsed = false;

    private void Awake()
    {
        if (this._interactPrompt == null) Debug.LogError("MISSING PROMPT");

        this._inputController = new InputController();
        this._inputController.PlayerGameplay.Interact.Enable();
        this._inputController.PlayerGameplay.Interact.performed += _ => CheckIfPlayerIsInCollider();
    }

    private void OnDisable()
    {
        this._inputController.PlayerGameplay.Interact.performed -= _ => CheckIfPlayerIsInCollider();
        this._inputController.PlayerGameplay.Interact.Disable();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(base._tagCheck)) return;

        this._isPlayerInside = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(_tagCheck)) return;

        this._isPlayerInside = false;
    }

    /// <summary>
    /// Gets called by the players interact input.
    /// Checks if the player is inside and if the button can be used.
    /// </summary>
    private void CheckIfPlayerIsInCollider()
    {
        if(!this._isPlayerInside) return;
        if (this._wasUsed && !this._buttonToggle) return;

        this._wasUsed = true;
        TriggerAction();
    } 

    /// <summary>
    /// The action that triggers the action event.
    /// </summary>
    public override void TriggerAction()
    {
        Debug.Log("BUTTON ACTION");
        base._actionEvent.Invoke();
    }
}
