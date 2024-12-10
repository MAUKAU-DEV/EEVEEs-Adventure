using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

/// <summary>
/// Manages the interaction prompt sprites for the Interaction System.
/// </summary>
public class InteractionPrompt: MonoBehaviour
{
    [SerializeField] private GameObject _keyboardPrompt;
    [SerializeField] private GameObject _gamepadPrompt;

    private InputController _inputController;

    private void Awake()
    {
        this._inputController = new InputController();

        InputUser.onChange += deviceChange;
    }

    private void OnDisable()
    {
        InputUser.onChange -= deviceChange;
    }

    /// <summary>
    /// Toggles the interaction sprite objects, based on which input the player used.
    /// </summary>
    /// <param name="user">The input information of the player.</param>
    /// <param name="change">NOT USED</param>
    /// <param name="device">NOT USED</param>
    private void deviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if(user.controlScheme == this._inputController.KeyboardScheme)
        {
            // Keyboard Input
            this._keyboardPrompt.SetActive(true);
            this._gamepadPrompt.SetActive(false);
        } else
        {
            // Gamepad Input
            this._gamepadPrompt.SetActive(true);
            this._keyboardPrompt.SetActive(false);
        }
    }

}
